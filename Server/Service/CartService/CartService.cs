using CakeStore.Server.Data;

namespace CakeStore.Server.Service.CartService
{
    public class CartService : ICartService
    {
        private readonly DataContext _context;

        public CartService(DataContext dataContext)
        {
            this._context = dataContext;
        }

        //获取购物车信息，将传入的购物车条目组织程一个新的整体CartCakeResponse
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
    }
}
