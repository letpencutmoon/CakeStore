using CakeStore.Server.Data;

namespace CakeStore.Server.Service.CakeTypeService
{
    public class CakeTypeService : ICakeTypeService
    {
        private readonly DataContext _context;

        public CakeTypeService(DataContext dataContext)
        {
            this._context = dataContext;
        }


        public async Task<ServiceResponse<List<CakeType>>> GetCakeTypes()
        {
            var cakeTypes = await _context.CakeType.ToListAsync();
            return new ServiceResponse<List<CakeType>> { Data = cakeTypes };
        }

        public async Task<ServiceResponse<List<CakeType>>> AddCakeType(CakeType cakeType)
        {
            cakeType.IsNew = false;
            cakeType.Editing = false;
            _context.CakeType.Add(cakeType);
            await _context.SaveChangesAsync();

            return await GetCakeTypes();
        }

        public async Task<ServiceResponse<List<CakeType>>> UpdateCakeType(CakeType cakeType)
        {
            var dbCakeType = await _context.CakeType.FindAsync(cakeType.Id);
            if(dbCakeType == null)
            {
                return new ServiceResponse<List<CakeType>>
                {
                    Success = false,
                    Message = "未找到对应类型"
                };
            }

            dbCakeType.Name = cakeType.Name;
            await _context.SaveChangesAsync();

            return await GetCakeTypes();
        }
    }
}
