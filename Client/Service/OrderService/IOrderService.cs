namespace CakeStore.Client.Service.OrderService
{
    public interface IOrderService
    {
        public Task PlaceOrder();

        public Task<List<OrderOverviewResponse>> GetOrders();
        public Task<OrderDetailsResponse> GetOrdersDetails(int orderId);
    }
}
