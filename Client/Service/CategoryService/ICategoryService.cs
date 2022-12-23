namespace CakeStore.Client.Service.CategoryService
{
    public interface ICategoryService
    {
        event Action OnChange;
        public List<Category> Categories { get; set; }
        public Task GetCategories();
        public ServiceResponse<Category> GetCategory(int id);

        //以下为管理员方法
        public List<Category> AdminCategories { get; set; }
        public Task GetAdminCategories();
        public Task AddCategory(Category category);
        public Task DeleteCategory(int categoryId);
        public Task UpdateCategory(Category category);
        public Category CreateNewCategory();
    }
}
