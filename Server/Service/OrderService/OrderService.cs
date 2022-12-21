using CakeStore.Server.Data;
using System.Security.Claims;

namespace CakeStore.Server.Service.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _context;
        private readonly ICartService _cartService;
        private readonly IAuthService _authService;

        public OrderService(DataContext dataContext,ICartService cartService,IAuthService authService)
        {
            this._context = dataContext;
            this._cartService = cartService;
            this._authService = authService;
        }

        //获取某个订单的信息
        public async Task<ServiceResponse<OrderDetailsResponse>> GetOrderDetails(int orderId)
        {
            var response = new ServiceResponse<OrderDetailsResponse>();
            var order = await _context.Order
                .Include(p => p.OrderItems)
                .ThenInclude(p => p.Cake)
                .Include(p => p.OrderItems)
                .ThenInclude(p => p.CakeType)
                .Where(p => p.UserId == _authService.GetUserId() && p.Id == orderId)
                .OrderByDescending(p => p.OrderDate)
                .FirstOrDefaultAsync();
            if (order == null)
            {
                response.Success = false;
                response.Message = "未找到订单";
                return response;
            }

            OrderDetailsResponse orderDetailsResponse = new()
            {
                OrderDate = order.OrderDate,
                TotalPrice = order.TotalPrice,
                Cakes = new List<OrderDetailsCakeResponse>()
            };

            order.OrderItems.ForEach(p=>
            orderDetailsResponse.Cakes.Add(new OrderDetailsCakeResponse()
            {
                CakeId = p.CakeId,
                ImageUrl = p.Cake.Imgurl,
                CakeType = p.CakeType.Name,
                Quantity = p.Quantity,
                Name = p.Cake.Name,
                TotalPrice=p.TotalPrice
            }
            ));

            response.Data = orderDetailsResponse;

            return response;
        }

        //获取订单信息
        public async Task<ServiceResponse<List<OrderOverviewResponse>>> GetOrders()
        {
            var response = new ServiceResponse<List<OrderOverviewResponse>>();

            //一个级联查询，从订单到订单项到蛋糕，查询当前用户的订单信息，根据时间逆序
            var orders = await _context.Order
                .Include(p => p.OrderItems)
                .ThenInclude(p => p.Cake)
                .Where(p => p.UserId == _authService.GetUserId())
                .OrderByDescending(p => p.OrderDate)
                .ToListAsync();

            var orderResponse = new List<OrderOverviewResponse>();
            orders.ForEach(p => orderResponse.Add(new OrderOverviewResponse
            {
                Id = p.Id,
                OrderDate = p.OrderDate,
                TotalPrice = p.TotalPrice,
                Cake = p.OrderItems.Count > 1 ?
                    $"订购了{p.OrderItems.First().Cake.Name}等{p.OrderItems.Count}件商品"
                    : p.OrderItems.First().Cake.Name,
                CakeImageUrl = p.OrderItems.First().Cake.Imgurl
            })) ;

            response.Data = orderResponse;
            return response;
        }

        public async Task<ServiceResponse<bool>> PlaceOrder()
        {
            var cakes = (await _cartService.GetDbCartCakes()).Data;
            decimal totalPrice = 0;
            cakes.ForEach(p => totalPrice += p.Price*p.Quantity);
            var orderItem =new List<OrderItem>();
            cakes.ForEach(p => orderItem.Add(new OrderItem
            {
                CakeId = p.CakeId,
                CakeTypeId = p.CakeTypeId,
                Quantity = p.Quantity,
                TotalPrice = p.Price * p.Quantity,
            }));

            var order = new Order
            {
                UserId = _authService.GetUserId(),
                OrderDate = DateTime.Now,
                TotalPrice = totalPrice,
                OrderItems = orderItem,
            };

            _context.Order.Add(order);

            _context.CartItem.RemoveRange(_context.CartItem.
                Where(p => p.UserId == _authService.GetUserId()));

            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Data = true };
        }

    }
}
