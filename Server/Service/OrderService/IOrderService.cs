namespace CakeStore.Server.Service.OrderService
{
    public interface IOrderService
    {
        public Task<ServiceResponse<bool>> PlaceOrder();
    }
}
