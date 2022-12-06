namespace CakeStore.Server.Service.CakeService
{
    public interface ICakeService
    {
        public abstract Task<ServiceResponse<List<Cake>>> GetCake();

    }
}
