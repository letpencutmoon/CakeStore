using Microsoft.AspNetCore.Components;

namespace CakeStore.Client.Service.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;
        private readonly IAuthService _authService;
        private readonly NavigationManager _navigationManager;

        public OrderService(HttpClient httpClient,IAuthService authService,NavigationManager navigationManager)
        {
            this._httpClient = httpClient;
            this._authService = authService;
            this._navigationManager = navigationManager;
        }

        public async Task<List<OrderOverviewResponse>> GetOrders()
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<List<OrderOverviewResponse>>>("api/order");
            return result.Data;
        }

        public async Task<OrderDetailsResponse> GetOrdersDetails(int orderId)
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<OrderDetailsResponse>>($"api/order/{orderId}");
            return result.Data;
        } 

        public async Task PlaceOrder()
        {
            if(await _authService.IsUserAuthenticated())
            {
                await _httpClient.PostAsync("api/order",null);
            }
            else
            {
                _navigationManager.NavigateTo("/LogIn");
            }
        }
    }
}
