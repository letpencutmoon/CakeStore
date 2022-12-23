using CakeStore.Server.Data;

namespace CakeStore.Server.Service.CakeService
{
    public class CakeService : ICakeService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpAccessor;

        public CakeService(DataContext context,IHttpContextAccessor httpAccessor)
        {
            this._context = context;
            this._httpAccessor = httpAccessor;
        }

        

        //商品展示
        public async Task<ServiceResponse<List<Cake>>> GetCake()
        {
            var cake = await _context.Cake
                .Where(p=>p.Visible && !p.IsDeleted)
                .Include(p =>p.CakeVariants.Where(p => p.Visible && !p.IsDeleted))
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
            Cake cake = null;
            if (_httpAccessor.HttpContext.User.IsInRole("Admin"))
            {
                cake = await _context.Cake
                .Include(v => v.CakeVariants.Where(p =>!p.IsDeleted))
                .ThenInclude(p => p.CakeType)
                .FirstOrDefaultAsync(p => p.ID == id &&!p.IsDeleted);
            }
            else
            {
                cake = await _context.Cake
                .Include(v => v.CakeVariants.Where(p => p.Visible && !p.IsDeleted))
                .ThenInclude(p => p.CakeType)
                .FirstOrDefaultAsync(p => p.ID == id && p.Visible && !p.IsDeleted);
            }

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
            var cake = await _context.Cake
                .Where(p=>(p.Name.Contains(searchText) || p.Description.Contains(searchText)) && !p.IsDeleted && p.Visible)
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
                .Where(p=>(p.Name.Contains(searchText) || p.Description.Contains(searchText)) && !p.IsDeleted && p.Visible)
                .Select(p => p.Name)
                .ToListAsync()
            };
            return response;
        }

        //管理员方法
        public async Task<ServiceResponse<List<Cake>>> GetAdminCake()
        {
            var cake = await _context.Cake
                .Where(p =>!p.IsDeleted)
                .Include(p => p.CakeVariants.Where(p=>!p.IsDeleted))
                .ThenInclude(p=>p.CakeType)
                .ToListAsync();
            ServiceResponse<List<Cake>> response = new()
            {
                Data = cake
            };

            return response;
        }

        public async Task<ServiceResponse<Cake>> UpdateCake(Cake cake)
        {
            var dbCake = await _context.Cake.FindAsync(cake.ID);
            if (dbCake == null)
            {
                return new ServiceResponse<Cake>
                {
                    Success = false,
                    Message = "未找到目标蛋糕"
                };
            }

            dbCake.Name = cake.Name;
            dbCake.Description = cake.Description;
            dbCake.CategoryId = cake.CategoryId;
            dbCake.Imgurl = cake.Imgurl;
            dbCake.Visible = cake.Visible;

            foreach(var variant in cake.CakeVariants)
            {
                var dbVariant = await _context.CakeVariant
                    .SingleOrDefaultAsync(p=>p.CakeId == variant.CakeId && p.CakeTypeId == variant.CakeTypeId);

                if(dbVariant == null)
                {
                    variant.CakeType = null;
                    _context.CakeVariant.Add(variant);
                }
                else
                {
                    dbVariant.CakeTypeId = variant.CakeTypeId;
                    dbVariant.Price = variant.Price;
                    dbVariant.OriginalPrice = variant.OriginalPrice;
                    dbVariant.Visible = variant.Visible;
                    dbVariant.IsDeleted = variant.IsDeleted;
                }
            }

            await _context.SaveChangesAsync();
            return new ServiceResponse<Cake> { Data = cake };
        }

        public async Task<ServiceResponse<Cake>> CreatCake(Cake cake)
        {
            foreach (var variant in cake.CakeVariants)
            {
                variant.CakeType = null;
            }
            _context.Cake.Add(cake);
            await _context.SaveChangesAsync();
            return new ServiceResponse<Cake> { Data = cake };
        }

        public async Task<ServiceResponse<bool>> Delete(int cakeId)
        {
            var dbCake = await _context.Cake.FindAsync(cakeId);
            if (dbCake == null)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Success = false,
                    Message = "未找到目标蛋糕"
                };
            }
            dbCake.IsDeleted = true;

            await _context.SaveChangesAsync();
            return new ServiceResponse<bool> { Data = true };

        }
    }
}
