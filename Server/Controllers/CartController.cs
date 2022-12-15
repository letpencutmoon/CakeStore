using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CakeStore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            this._cartService = cartService;
        }

        [HttpPost("cakes")]
        public async Task<ActionResult<ServiceResponse<List<CartCakeResponse>>>> GetCakeCart(List<CartItem> cartItems) 
        {
            var result = await _cartService.GetCakeCarts(cartItems);
            return Ok(result);
        }
    }
}
