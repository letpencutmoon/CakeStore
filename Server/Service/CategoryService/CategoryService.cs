using CakeStore.Server.Data;

namespace CakeStore.Server.Service.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly DataContext _context;

        public CategoryService(DataContext context)
        {
            this._context = context;
        }

        public async Task<ServiceResponse<List<Category>>> GetCategories()
        {
            var categories =await  _context.Category
                .Where(c => !c.IsDeleted && c.Visible)
                .ToListAsync();
            ServiceResponse<List<Category>> response = new()
            {
                Data = categories
            };
            return response;
        }

        public async Task<ServiceResponse<Category>> GetCategory(int id)
        {
            var category = await _context.Category.FindAsync(id);
            ServiceResponse<Category> response = new()
            {
                Data = category
            };

            return response;
        }

        //以下是管理员方法
        public async Task<ServiceResponse<List<Category>>> UpdateCategories(Category category)
        {
            var dbcategory =await _context.Category.FirstOrDefaultAsync(p=>p.ID == category.ID);
            if (category == null)
            {
                return new ServiceResponse<List<Category>>
                {
                    Success = false,
                    Message = "没有找到该类别"
                };
            }

            dbcategory.Name = category.Name;
            dbcategory.Url = category.Url;
            dbcategory.Visible = category.Visible;

            await _context.SaveChangesAsync();

            return await GetAdminCategories();
        }

        public async Task<ServiceResponse<List<Category>>> AddCategory(Category category)
        {
            category.Editing = false;
            category.IsNew = false;

            await _context.Category.AddAsync(category);
            await _context.SaveChangesAsync();

            return await GetAdminCategories();
        }

        public async Task<ServiceResponse<List<Category>>> DeleteCategories(int categoryId)
        {
            var category =await _context.Category.FirstOrDefaultAsync(p=>p.ID == categoryId);
            if(category == null)
            {
                return new ServiceResponse<List<Category>>
                {
                    Success = false,
                    Message = "没有找到该类别"
                };
            }

            category.IsDeleted = true;
            await _context.SaveChangesAsync();
            return await GetAdminCategories();
        }

        public async Task<ServiceResponse<List<Category>>> GetAdminCategories()
        {
            var categories = await _context.Category
                .Where(c => !c.IsDeleted)
                .ToListAsync();
            ServiceResponse<List<Category>> response = new()
            {
                Data = categories
            };
            return response;
        }
    }
}
