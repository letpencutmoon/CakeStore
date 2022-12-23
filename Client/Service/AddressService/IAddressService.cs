namespace CakeStore.Client.Service.AddressService
{
    public interface IAddressService
    {
        public Task<Address> GetAddress();

        public Task<Address> AddOrUpdateAddress(Address address);
    }
}
