namespace CakeStore.Server.Service.CakeService
{
    public interface ICakeService
    {
        public abstract Task<ServiceResponse<List<Cake>>> GetCake();

        public abstract Task<ServiceResponse<Cake>> GetCake(int id);

    }
}
