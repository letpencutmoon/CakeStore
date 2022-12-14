namespace CakeStore.Server.Service.CakeService
{
    public interface ICakeService
    {
        public abstract Task<ServiceResponse<List<Cake>>> GetCake();

        public abstract Task<ServiceResponse<Cake>> GetCake(int id);

        public abstract Task<ServiceResponse<List<Cake>>> Search(string searchText);

        public abstract Task<ServiceResponse<List<string>>> Searchsuggestions(string searchText);

    }
}
