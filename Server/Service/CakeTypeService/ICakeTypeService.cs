namespace CakeStore.Server.Service.CakeTypeService
{
    public interface ICakeTypeService
    {
        public Task<ServiceResponse<List<CakeType>>> GetCakeTypes();
        public Task<ServiceResponse<List<CakeType>>> AddCakeType(CakeType cakeType);
        public Task<ServiceResponse<List<CakeType>>> UpdateCakeType(CakeType cakeType);

    }
}
