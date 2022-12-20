using Blazored.LocalStorage;

namespace CakeStore.Client.Service.CartService
{
    public class CartService : ICartService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly HttpClient _httpClient;

        //public event Action OnChange;

        public CartService(ILocalStorageService localStorage,HttpClient httpClient)
        {
            this._localStorage = localStorage;
            this._httpClient = httpClient;
        }
        //将单条信息添加到本地购物车（类似于session？）
        public async Task AddToCart(CartItem cartItem)
        {
            var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
            if(cart == null)
            {
                cart = new List<CartItem>();
            }

            var sameItem = cart.Find(p=>p.CakeId == cartItem.CakeId && p.CakeTypeId==cartItem.CakeTypeId);
            if(sameItem == null)
            {
                cart.Add(cartItem);
            }
            else
            {
                sameItem.Quantity +=cartItem.Quantity;
            }
            await _localStorage.SetItemAsync("cart",cart);
        }

        //从本地存储库获取或创建购物车条目信息
        public async Task<List<CartItem>> GetCatItems()
        {
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
            var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
            var response = await _httpClient.PostAsJsonAsync("api/Cart/cakes", cart);
            var cakecart = await response.Content.ReadFromJsonAsync<ServiceResponse<List<CartCakeResponse>>>();
            return cakecart.Data; 
        }

        public async Task RemoveCakeFromCart(int cakeId, int cakeTypeId)
        {
            var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
            if (cart == null) return;

            var cartItem = cart.Find(p=>p.CakeId == cakeId && p.CakeTypeId == cakeTypeId);
            if (cartItem != null)
            {
                cart.Remove(cartItem);
                await _localStorage.SetItemAsync("cart",cart);
            }
        }

        public async Task UpdateQuantity(CartCakeResponse cartResponse)
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
}
