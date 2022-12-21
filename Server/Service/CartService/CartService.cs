using CakeStore.Server.Data;
using System.Security.Claims;

namespace CakeStore.Server.Service.CartService
{
    public class CartService : ICartService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CartService(DataContext dataContext,IHttpContextAccessor httpContextAccessor)
        {
            this._context = dataContext;
            this._httpContextAccessor = httpContextAccessor;
        }

        public async Task<ServiceResponse<bool>> AddToCart(CartItem cartItem)
        {
            cartItem.UserId = GetUerId();

            //判断是否已有，已有就加数量，没有就新建
            var sameItem = await _context.CartItem
                .FirstOrDefaultAsync(p=>p.CakeId == cartItem.CakeId && p.CakeTypeId == cartItem.CakeTypeId && p.UserId == cartItem.UserId);

            if(sameItem == null)
            {
                _context.CartItem.Add(cartItem);
            }
            else
            {
                sameItem.Quantity += cartItem.Quantity;
            }
            
            await _context.SaveChangesAsync();
            return new ServiceResponse<bool> { Data=true };
        }

        //获取购物车信息，将传入的购物车条目组织成一个新的整体CartCakeResponse
        public async Task<ServiceResponse<List<CartCakeResponse>>> GetCakeCarts(List<CartItem> cartItems)
        {
            ServiceResponse<List<CartCakeResponse>> serviceResponse = new()
            {
                Data = new List<CartCakeResponse>()
            };

            //根据购物车的单个条目的信息查取相关所有信息并写入CartCakeResponse中
            foreach(var cartCake in cartItems)
            {
                var cake = await _context.Cake
                    .Where(p => p.ID == cartCake.CakeId)
                    .FirstOrDefaultAsync();

                if (cake == null) continue;
                var cakeVariant = await _context.CakeVariant
                    .Where(p => p.CakeId == cartCake.CakeId && p.CakeTypeId == cartCake.CakeTypeId)
                    .Include(p=>p.CakeType)
                    .FirstOrDefaultAsync();
                if(cakeVariant == null) continue;
                CartCakeResponse cartResponse = new() 
                {
                    CakeId = cake.ID,
                    Name = cake.Name,
                    Imgurl = cake.Imgurl,
                    Price = cakeVariant.Price,
                    CakeType = cakeVariant.CakeType.Name,
                    CakeTypeId = cakeVariant.CakeTypeId,
                    Quantity = cartCake.Quantity
                };

                serviceResponse.Data.Add(cartResponse);
            }

            return serviceResponse;

        }

        public async Task<ServiceResponse<int>> GetCartItemsCount()
        {
            int count = (await _context.CartItem.Where(p=>p.UserId == GetUerId()).ToListAsync()).Count;
            return new ServiceResponse<int> { Data = count };
        }

        public async Task<ServiceResponse<List<CartCakeResponse>>> GetDbCartCakes()
        {
            return await GetCakeCarts(await _context.CartItem.Where(p=>p.UserId == GetUerId()).ToListAsync());
        }

        public async Task<ServiceResponse<bool>> RemoveItemFromCart(int cakeId,int cakeTypeId)
        {
            var dbItem = await _context.CartItem
                .FirstOrDefaultAsync(p => p.CakeId == cakeId && p.CakeTypeId == cakeTypeId);
            if (dbItem == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "当前蛋糕不存在"
                };
            }

            _context.CartItem.Remove(dbItem);
            await _context.SaveChangesAsync();
            return new ServiceResponse<bool> { Data = true };
        }

        //将本地购物车加到数据库并取出当前用户所有购物车信息
        public async Task<ServiceResponse<List<CartCakeResponse>>> StoreCartItems(List<CartItem> cartItems)
        {
            int userId = GetUerId();
            cartItems.ForEach(cartItem => cartItem.UserId = userId);
            _context.CartItem.AddRange(cartItems);
            await _context.SaveChangesAsync();
            return await GetDbCartCakes();
        }

        public async Task<ServiceResponse<bool>> UpdateQuantity(CartItem cartItem)
        {
            var dbItem = await _context.CartItem
                .FirstOrDefaultAsync(p => p.CakeId == cartItem.CakeId && p.CakeTypeId == cartItem.CakeTypeId && p.UserId == cartItem.UserId);
            if(dbItem == null)
            {
                return new ServiceResponse<bool> 
                {
                    Success = false,
                    Data = false,
                    Message = "当前蛋糕不存在"
                };
            }
            dbItem.Quantity = cartItem.Quantity;
            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Data = true };
        }

        //从上下文获取用户登录后的信息
        private int GetUerId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
    }
}
