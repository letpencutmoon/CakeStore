using CakeStore.Server.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CakeStore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CakeController : ControllerBase
    {
        private readonly DataContext _context;
        public CakeController(DataContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cake>>> GetCake(){
            var cakes = await _context.Cake.ToListAsync();
            return Ok(cakes);
        }
    }
}
