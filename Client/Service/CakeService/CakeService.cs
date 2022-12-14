namespace CakeStore.Client.Service.CakeService
{
    public class CakeService : ICakeService
    {
        private readonly HttpClient _httpClient;
        public List<Cake> Cakes { get; set; } = new();

        public CakeService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task GetCakes()
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Cake>>>("api/Cake");
            if (response != null && response.Data != null) Cakes = response.Data;
        }

        public async Task<ServiceResponse<Cake>> GetCake(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<Cake>>($"api/Cake/{id}");
            
            return response!;
        }

        public async Task<ServiceResponse<List<Cake>>> SearchCakes(string searchText)
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Cake>>>($"api/Cake/Search/{searchText}");
            return response!;
        }

        public async Task<ServiceResponse<List<string>>> SearchSuggestions(string searchText)
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<string>>>($"api/Cake/SearchSuggestion/{searchText}");
            return response!;
        }
    }
}
