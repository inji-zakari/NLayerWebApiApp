using Microsoft.EntityFrameworkCore;
using NLayerWebApi.Core.Entities;
using NLayerWebApi.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerWebApi.Repository.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {

        public CategoryRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Category> GetCategoryByIdWithProducts(int categoryId)
        {
            return await _dbContext.Categories.Include(x => x.Products).Where(x => x.Id == categoryId).SingleOrDefaultAsync();
        }
    }
}
