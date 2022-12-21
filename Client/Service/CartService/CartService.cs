using Blazored.LocalStorage;

namespace CakeStore.Client.Service.CartService
{
    public class CartService : ICartService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        //public event Action OnChange;

        public CartService(ILocalStorageService localStorage,HttpClient httpClient,AuthenticationStateProvider authenticationStateProvider)
        {
            this._localStorage = localStorage;
            this._httpClient = httpClient;
            this._authenticationStateProvider = authenticationStateProvider;
        }
        //将单条信息添加到本地购物车（类似于session？）
        public async Task AddToCart(CartItem cartItem)
        {
            if(await IsUserAuthenticated())
            {
                await _httpClient.PostAsJsonAsync("api/cart/add",cartItem);
            }
            else
            {
                var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
                if (cart == null)
                {
                    cart = new List<CartItem>();
                }

                var sameItem = cart.Find(p => p.CakeId == cartItem.CakeId && p.CakeTypeId == cartItem.CakeTypeId);
                if (sameItem == null)
                {
                    cart.Add(cartItem);
                }
                else
                {
                    sameItem.Quantity += cartItem.Quantity;
                }
                await _localStorage.SetItemAsync("cart", cart);
            }

            
            await GetCarItemsCount();
        }

        //从本地存储库获取或创建购物车条目信息
        public async Task<List<CartItem>> GetCatItems()
        {
            await GetCarItemsCount();
            var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
            if (cart == null)
            {
                cart = new List<CartItem>();
            }
            return cart;
        }

        //将条目信息上传获取具体信息
        public async Task<List<CartCakeResponse>> GetCakeCarts()
        {
            if(await IsUserAuthenticated())
            {
                var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<CartCakeResponse>>>("api/Cart");
                return response.Data;
            }
            else
            {
                var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
                if (cart == null) return new List<CartCakeResponse>();
                var response = await _httpClient.PostAsJsonAsync("api/Cart/cakes", cart);
                var cakecart = await response.Content.ReadFromJsonAsync<ServiceResponse<List<CartCakeResponse>>>();
                return cakecart.Data;
            }
             
        }

        public async Task RemoveCakeFromCart(int cakeId, int cakeTypeId)
        {
            if(await IsUserAuthenticated())
            {
                await _httpClient.DeleteAsync($"api/cart/{cakeId}/{cakeTypeId}");
            }
            else
            {
                var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
                if (cart == null) return;

                var cartItem = cart.Find(p => p.CakeId == cakeId && p.CakeTypeId == cakeTypeId);
                if (cartItem != null)
                {
                    cart.Remove(cartItem);
                    await _localStorage.SetItemAsync("cart", cart);
                }
            }
            await GetCarItemsCount();
        }

        public async Task UpdateQuantity(CartCakeResponse cartResponse)
        {
            if(await IsUserAuthenticated())
            {
                CartItem request = new()
                {
                    CakeId = cartResponse.CakeId,
                    CakeTypeId = cartResponse.CakeTypeId,
                    Quantity = cartResponse.Quantity
                };

                await _httpClient.PutAsJsonAsync("api/cart/update-quantity",request);
            }
            else
            {
                var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
                if (cart == null) return;

                var cartItem = cart.Find(p => p.CakeId == cartResponse.CakeId && p.CakeTypeId == cartResponse.CakeTypeId);
                if (cartItem != null)
                {
                    cartItem.Quantity = cartResponse.Quantity;
                    await _localStorage.SetItemAsync("cart", cart);
                }
            }
        }

        public async Task StoreCartItem(bool emptyLocalCart=false)
        {
            var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
            if (cart == null) return;

            await _httpClient.PostAsJsonAsync("api/Cart",cart);

            if (emptyLocalCart)
            {
                await _localStorage.RemoveItemAsync("cart");
            }
        }

        public async Task GetCarItemsCount()
        {
            if(await IsUserAuthenticated())
            {
                var result = await _httpClient.GetFromJsonAsync<ServiceResponse<int>>("api/cart/count");
                int count = result.Data;

                await _localStorage.SetItemAsync<int>("CartItemsCount",count);
            }
            else
            {
                var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
                await _localStorage.SetItemAsync<int>("CartItemsCount", cart == null ? 0:cart.Count);
            }
        }

        private async Task<bool> IsUserAuthenticated() => (await _authenticationStateProvider.GetAuthenticationStateAsync()).User.Identity.IsAuthenticated;
    }
}
