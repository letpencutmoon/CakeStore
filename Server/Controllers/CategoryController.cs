using Microsoft.AspNetCore.Mvc;
using CakeStore.Server.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace CakeStore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController: ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryservice )
        {
            this._categoryService = categoryservice;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Category>>>> GetCategories()
        {
            var result = await _categoryService.GetCategories();
            return Ok(result);
        }

        //以下是管理员方法

        [HttpGet("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<Category>>>> GetAdminCategories()
        {
            var result = await _categoryService.GetAdminCategories();
            return Ok(result);
        }

        [HttpDelete("admin/{categoryId}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<Category>>>> DeleteCategory(int categoryId)
        {
            var result = await _categoryService.DeleteCategories(categoryId);
            return Ok(result);
        }

        [HttpPost("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<Category>>>> AddCategory(Category category)
        {
            var result = await _categoryService.AddCategory(category);
            return Ok(result);
        }

        [HttpPut("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<Category>>>> UpdateCategory(Category category)
        {
            var result = await _categoryService.UpdateCategories(category);
            return Ok(result);
        }
    }
}
