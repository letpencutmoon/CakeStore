namespace CakeStore.Server.Service.CakeService
{
    public interface ICakeService
    {
        public Task<ServiceResponse<List<Cake>>> GetCake();

        public Task<ServiceResponse<Cake>> GetCake(int id);

        public Task<ServiceResponse<List<Cake>>> Search(string searchText);

        public Task<ServiceResponse<List<string>>> Searchsuggestions(string searchText);



        public Task<ServiceResponse<Cake>> CreatCake(Cake cake);
        public Task<ServiceResponse<Cake>> UpdateCake(Cake cake);
        public Task<ServiceResponse<bool>> Delete(int cakeId);

        public Task<ServiceResponse<List<Cake>>> GetAdminCake();

    }
}
