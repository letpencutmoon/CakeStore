using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CakeStore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class CakeTypeController : ControllerBase
    {
        private readonly ICakeTypeService _cakeTypeService;

        public CakeTypeController(ICakeTypeService cakeTypeService)
        {
            this._cakeTypeService = cakeTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<CakeType>>>> GetCakeTypes()
        {
            var result = await _cakeTypeService.GetCakeTypes();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<CakeType>>>> AddCakeType(CakeType cakeType)
        {
            var result = await _cakeTypeService.AddCakeType(cakeType);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<CakeType>>>> UpdateCakeType(CakeType cakeType)
        {
            var result = await _cakeTypeService.UpdateCakeType(cakeType);
            return Ok(result);
        }
    }
}
