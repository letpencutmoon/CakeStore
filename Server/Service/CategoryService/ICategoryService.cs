namespace CakeStore.Server.Service.CategoryService
{
    public interface ICategoryService
    {
        public Task<ServiceResponse<List<Category>>> GetCategories();

        public Task<ServiceResponse<Category>> GetCategory(int id);
    }
}
