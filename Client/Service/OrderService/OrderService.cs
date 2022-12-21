using Microsoft.AspNetCore.Components;

namespace CakeStore.Client.Service.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly NavigationManager _navigationManager;

        public OrderService(HttpClient httpClient,AuthenticationStateProvider authenticationStateProvider,NavigationManager navigationManager)
        {
            this._httpClient = httpClient;
            this._authStateProvider = authenticationStateProvider;
            this._navigationManager = navigationManager;
        }
        public async Task PlaceOrder()
        {
            if(await IsUserAuthenticated())
            {
                await _httpClient.PostAsync("api/order",null);
            }
            else
            {
                _navigationManager.NavigateTo("/LogIn");
            }
        }

        private async Task<bool> IsUserAuthenticated() => (await _authStateProvider.GetAuthenticationStateAsync()).User.Identity.IsAuthenticated;

    }
}
