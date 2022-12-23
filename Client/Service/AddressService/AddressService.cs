namespace CakeStore.Client.Service.AddressService
{
    public class AddressService : IAddressService
    {
        private readonly HttpClient _http;

        public AddressService(HttpClient httpClient)
        {
            this._http = httpClient;
        }
        public async Task<Address> AddOrUpdateAddress(Address address)
        {
            var response = await _http.PostAsJsonAsync("api/Address",address);
            return response.Content.ReadFromJsonAsync<ServiceResponse<Address>>().Result.Data;
        }

        public async Task<Address> GetAddress()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<Address>>("api/Address");
            return response.Data;
        }
    }
}
