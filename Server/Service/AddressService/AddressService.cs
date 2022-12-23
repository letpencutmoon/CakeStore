using CakeStore.Server.Data;

namespace CakeStore.Server.Service.AddressService
{
    public class AddressService:IAddressService
    {
        private readonly DataContext _context;
        private readonly IAuthService _authService;

        public AddressService(DataContext dataContext,IAuthService authService)
        {
            this._context = dataContext;
            this._authService = authService;
        }

        public async Task<ServiceResponse<Address>> AddOrUpdateAddress(Address address)
        {
            var response = new ServiceResponse<Address>();
            var dbAddress = (await GetAddress()).Data;
            if(dbAddress == null)
            {
                address.UserId = _authService.GetUserId();
                _context.Address.Add(address);
                response.Data = address;
            }
            else
            {
                dbAddress.Name = address.Name;
                dbAddress.Street = address.Street;
                dbAddress.City = address.City;
                dbAddress.Province = address.Province;
                dbAddress.Zip = address.Zip;
            }

            await _context.SaveChangesAsync();
            return response;
        }

        public async Task<ServiceResponse<Address>> GetAddress()
        {
            int userId = _authService.GetUserId();
            Address address =await _context.Address.FirstOrDefaultAsync(p=>p.UserId == userId);
            return new ServiceResponse<Address> { Data = address };
        }
    }
}
