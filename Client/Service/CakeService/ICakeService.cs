namespace CakeStore.Client.Service.CakeService
{
    public interface ICakeService
    {
        public List<Cake> Cakes { get; set; }
        public Task<ServiceResponse<Cake>>  GetCake(int id);

        public Task GetCakes();
    }
}
