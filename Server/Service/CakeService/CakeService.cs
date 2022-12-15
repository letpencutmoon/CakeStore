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
        //商品展示
        public async Task<ServiceResponse<List<Cake>>> GetCake()
        {
            var cake = await _context.Cake
                .Include(navigationPropertyPath: p =>p.CakeVariants)
                .ToListAsync();
            ServiceResponse<List<Cake>> response = new()
            {
                Data = cake
            };

            return response;
        }

        //商品详细信息
        public async Task<ServiceResponse<Cake>> GetCake(int id)
        {
            var response = new ServiceResponse<Cake>();
            var cake = await _context.Cake
                .Include(v => (v as Cake).CakeVariants)
                .ThenInclude(p => (p as CakeVariant).CakeType)
                .FirstOrDefaultAsync(p=>p.ID == id);
            
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

        //搜索结果
        public async Task<ServiceResponse<List<Cake>>> Search(string searchText)
        {
            var response = new ServiceResponse<List<Cake>>();
            var cake = await _context.Cake.Where(p=>p.Name.Contains(searchText) || p.Description.Contains(searchText))
                .Include(v => (v as Cake).CakeVariants)
                .ToListAsync();
            response.Data = cake;
            return response;
        }

        //搜索推荐
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
