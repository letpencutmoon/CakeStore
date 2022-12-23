using CakeStore.Server.Data;
using CakeStore.Server.Service.CakeService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CakeStore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CakeController : ControllerBase
    {
        private readonly ICakeService _cakeService;

        public CakeController( ICakeService cakeService)
        {
            this._cakeService = cakeService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Cake>>>> GetCake(){
            var result = await _cakeService.GetCake();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Cake>>> GetCake(int id)
        {
            var result = await _cakeService.GetCake(id);
            return Ok(result);
        }

        [HttpGet("Search/{searchText}")]
        public async Task<ServiceResponse<List<Cake>>> Search(string searchText)
        {
            var result = await _cakeService.Search(searchText);
            return result;
        }

        [HttpGet("SearchSuggestion/{searchText}")]
        public async Task<ServiceResponse<List<string>>> SeachSuggestion(string searchText)
        {
            var result = await _cakeService.Searchsuggestions(searchText);
            return result;
        }

        [HttpGet("admin"),Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<Cake>>>> GetAdminCake()
        {
            var result = await _cakeService.GetAdminCake();
            return Ok(result);
        }

        [HttpPost, Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<Cake>>> CreateCake(Cake cake)
        {
            var result = await _cakeService.CreatCake(cake);
            return Ok(result);
        }

        [HttpPut, Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<Cake>>> UpdateCake(Cake cake)
        {
            var result = await _cakeService.UpdateCake(cake);
            return Ok(result);
        }

        [HttpDelete("{cakeId}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteCake(int cakeId)
        {
            var result = await _cakeService.Delete(cakeId);
            return Ok(result);
        }
    }
}
