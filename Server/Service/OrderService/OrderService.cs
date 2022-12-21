using CakeStore.Server.Data;
using System.Security.Claims;

namespace CakeStore.Server.Service.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _context;
        private readonly ICartService _cartService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public OrderService(DataContext dataContext,ICartService cartService,IHttpContextAccessor httpContextAccessor)
        {
            this._context = dataContext;
            this._cartService = cartService;
            this._httpContextAccessor = httpContextAccessor;
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
                UserId = GetUerId(),
                OrderDate = DateTime.Now,
                TotalPrice = totalPrice,
                OrderItems = orderItem,
            };

            _context.Order.Add(order);
            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Data = true };
        }

        private int GetUerId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
    }
}
