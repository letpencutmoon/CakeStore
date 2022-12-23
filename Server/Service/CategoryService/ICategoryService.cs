namespace CakeStore.Server.Service.CategoryService
{
    public interface ICategoryService
    {
        public Task<ServiceResponse<List<Category>>> GetCategories();

        public Task<ServiceResponse<Category>> GetCategory(int id);

        public Task<ServiceResponse<List<Category>>> GetAdminCategories();
        public Task<ServiceResponse<List<Category>>> AddCategory(Category category);
        public Task<ServiceResponse<List<Category>>> UpdateCategories(Category category);
        public Task<ServiceResponse<List<Category>>> DeleteCategories(int categoryId);

    }
}
