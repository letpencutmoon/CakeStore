namespace CakeStore.Client.Service.CakeService
{
    public interface ICakeService
    {
        public List<Cake> Cakes { get; set; }
        public Task<ServiceResponse<Cake>>  GetCake(int id);
        public Task GetCakes();

        public Task<ServiceResponse<List<Cake>>> SearchCakes(string searchText);

        public Task<ServiceResponse<List<string>>> SearchSuggestions(string searchText);
    }
}
