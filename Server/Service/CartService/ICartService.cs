namespace CakeStore.Server.Service.CartService
{
    public interface ICartService
    {
        public Task<ServiceResponse<List<CartCakeResponse>>> GetCakeCarts(List<CartItem> cartItems); 
    }
}
