﻿namespace CakeStore.Client.Service.CakeService
{
    public class CakeService : ICakeService
    {
        private readonly HttpClient _httpClient;
         public List<Cake> Cakes { get; set; } = new();

        public CakeService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task GetCake()
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Cake>>>("api/Cake");
            if(response != null && response.Data !=null) Cakes = response.Data;
        }
    }
}
