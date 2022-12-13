using CakeStore.Server.Data;

namespace CakeStore.Server.Service.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly DataContext _cotext;

        public CategoryService(DataContext context)
        {
            this._cotext = context;
        }
        public async Task<ServiceResponse<List<Category>>> GetCategories()
        {
            var categories =await  _cotext.Category.ToListAsync();
            ServiceResponse<List<Category>> response = new()
            {
                Data = categories
            };
            return response;
        }

        public async Task<ServiceResponse<Category>> GetCategory(int id)
        {
            var category = await _cotext.Category.FindAsync(id);
            ServiceResponse<Category> response = new()
            {
                Data = category
            };

            return response;
        }
    }
}
