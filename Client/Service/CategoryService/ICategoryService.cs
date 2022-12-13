namespace CakeStore.Client.Service.CategoryService
{
    public interface ICategoryService
    {
        public List<Category> Categories { get; set; }
        public Task GetCategories();

        public ServiceResponse<Category> GetCategory(int id);
    }
}
