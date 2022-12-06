using CakeStore.Server.Data;

namespace CakeStore.Server.Service.CakeService
{
    public class CakeService : ICakeService
    {
        private readonly DataContext _context;
        public CakeService(DataContext context)
        {
            this._context = context;
        }
        public async Task<ServiceResponse<List<Cake>>> GetCake()
        {
            var cake = await _context.Cake.ToListAsync();
            ServiceResponse<List<Cake>> response = new()
            {
                Data = cake
            };

            return response;
        }
    }
}
