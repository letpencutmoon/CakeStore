namespace CakeStore.Client.Service.CakeService
{
    public class CakeService : ICakeService
    {
        private readonly HttpClient _httpClient;
        public List<Cake> Cakes { get; set; } = new();
        public List<Cake> AdminCakes { get; set; } = new();

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


        public async Task<Cake> CreateCake(Cake cake)
        {
            var result = await _httpClient.PostAsJsonAsync("api/cake",cake);
            var newCake = (await result.Content.ReadFromJsonAsync<ServiceResponse<Cake>>()).Data;
            return newCake;
        }

        public async Task<Cake> UpdateCake(Cake cake)
        {
            var result = await _httpClient.PutAsJsonAsync("api/cake",cake);
            return (await result.Content.ReadFromJsonAsync<ServiceResponse<Cake>>()).Data;
        }

        public async Task DeleteCake(Cake cake)
        {
            var result = await _httpClient.DeleteAsync($"api/cake/{cake.ID}");
        }

        public async Task GetAdminCakes()
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Cake>>>("api/cake/admin");
            AdminCakes = result.Data;
        }
    }
}
