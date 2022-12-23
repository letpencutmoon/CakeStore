namespace CakeStore.Client.Service.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public event Action OnChange;

        public List<Category> Categories { get; set; } = new();
        

        public CategoryService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }
        public async Task GetCategories()
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Category>>>("api/Category");
            if (result != null && result.Data != null) Categories = result.Data;
        }

        public ServiceResponse<Category> GetCategory(int id)
        {
            throw new NotImplementedException();
        }

        //以下是管理员方法
        public List<Category> AdminCategories { get; set; } = new();

        public async Task GetAdminCategories()
        {
             var result = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Category>>>("api/Category/admin");
             if (result != null && result.Data != null) AdminCategories = result.Data;
        }

        public async Task AddCategory(Category category)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Category/admin",category);
            AdminCategories = (await result.Content
                .ReadFromJsonAsync<ServiceResponse<List<Category>>>()).Data;

            await GetCategories();
            OnChange.Invoke();
        }
        
        public async Task DeleteCategory(int categoryId)
        {
            var result = await _httpClient.DeleteAsync($"api/Category/admin/{categoryId}");
            AdminCategories = (await result.Content
                .ReadFromJsonAsync<ServiceResponse<List<Category>>>()).Data;

            await GetCategories();
            OnChange.Invoke();
        }

        public async Task UpdateCategory(Category category)
        {
            var result = await _httpClient.PutAsJsonAsync("api/Category/admin", category);
            AdminCategories = (await result.Content
                .ReadFromJsonAsync<ServiceResponse<List<Category>>>()).Data;

            await GetCategories();
            OnChange.Invoke();
        }

        public Category CreateNewCategory()
        {
            var newCategory = new Category()
            {
                Editing = true,
                IsNew = true
            };
            AdminCategories.Add(newCategory);
            OnChange.Invoke();
            return newCategory;
        }
    }
}
