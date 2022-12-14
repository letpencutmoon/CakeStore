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

        public async Task<ServiceResponse<Cake>> GetCake(int id)
        {
            var response = new ServiceResponse<Cake>();
            var cake = await _context.Cake.FindAsync(id);
            
            if(cake != null)
            {
                response.Data = cake;
            }
            else
            {
                response.Success = false;
            }

            return response;
        }

        public async Task<ServiceResponse<List<Cake>>> Search(string searchText)
        {
            var response = new ServiceResponse<List<Cake>>();
            var cake = await _context.Cake.Where(p=>p.Name.Contains(searchText) || p.Description.Contains(searchText)).ToListAsync();
            response.Data = cake;
            return response;
        }

        public async Task<ServiceResponse<List<string>>> Searchsuggestions(string searchText)
        {
            var response = new ServiceResponse<List<string>>()
            {
                Data = await _context.Cake
                .Where(p=>p.Name.Contains(searchText) || p.Description.Contains(searchText))
                .Select(p => p.Name)
                .ToListAsync()
            };
            return response;
        }
    }
}
