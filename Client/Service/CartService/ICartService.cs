namespace CakeStore.Client.Service.CartService
{
    public interface ICartService
    {
        event Action OnChange;
        public Task AddToCart(CartItem cartItem);
        public Task<List<CartItem>> GetCatItems();
        public Task<List<CartCakeResponse>> GetCakeCarts();
        public Task RemoveCakeFromCart(int cakeId,int cakeTypeId);

        public Task UpdateQuantity(CartCakeResponse cartResponse);
    }
}
