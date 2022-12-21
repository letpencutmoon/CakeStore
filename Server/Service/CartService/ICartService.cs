namespace CakeStore.Server.Service.CartService
{
    public interface ICartService
    {
        public Task<ServiceResponse<List<CartCakeResponse>>> GetCakeCarts(List<CartItem> cartItems);

        public Task<ServiceResponse<List<CartCakeResponse>>> StoreCartItems(List<CartItem> cartItems);

        public Task<ServiceResponse<List<CartCakeResponse>>> GetDbCartCakes();
        public Task<ServiceResponse<bool>> AddToCart(CartItem cartItem);
        public Task<ServiceResponse<bool>> UpdateQuantity(CartItem cartItem);

        public Task<ServiceResponse<bool>> RemoveItemFromCart(int cakeId,int cakeTypeId);

        public Task<ServiceResponse<int>> GetCartItemsCount();
    }
}
