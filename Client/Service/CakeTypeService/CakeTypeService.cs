namespace CakeStore.Client.Service.CakeTypeService
{
    public class CakeTypeService : ICakeTypeService
    {
        private readonly HttpClient _http;

        public CakeTypeService(HttpClient httpClient)
        {
            this._http = httpClient;
        }

        public List<CakeType> CakeTypes { get; set; } = new();

        public event Action OnChange;

        public async Task GetCakeTypes()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<CakeType>>>("api/caketype");
            CakeTypes = result.Data;
        }

        public async Task AddCakeType(CakeType cakeType)
        {
            var result = await _http.PostAsJsonAsync("api/caketype",cakeType);
            CakeTypes = (await result.Content.ReadFromJsonAsync<ServiceResponse<List<CakeType>>>()).Data;
            OnChange.Invoke();
        }

        public CakeType CreateNewCakeType()
        {
            CakeType newCakeType = new()
            {
                IsNew = true,
                Editing = true,
            };
            CakeTypes.Add(newCakeType);
            OnChange.Invoke();

            return newCakeType;
        }

        public async Task UpdateCakeType(CakeType cakeType)
        {
            var result = await _http.PutAsJsonAsync("api/caketype", cakeType);
            CakeTypes = (await result.Content.ReadFromJsonAsync<ServiceResponse<List<CakeType>>>()).Data;
            OnChange.Invoke();
        }
    }
}
