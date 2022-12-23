namespace CakeStore.Client.Service.CakeTypeService
{
    public interface ICakeTypeService 
    {
        public event Action OnChange;

        public List<CakeType> CakeTypes { get; set; }
        public Task GetCakeTypes();

        public Task AddCakeType(CakeType cakeType);
        public Task UpdateCakeType(CakeType cakeType);
        public CakeType CreateNewCakeType();
    }
}
