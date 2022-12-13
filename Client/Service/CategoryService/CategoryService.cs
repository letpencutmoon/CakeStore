namespace CakeStore.Client.Service.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;
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
    }
}
