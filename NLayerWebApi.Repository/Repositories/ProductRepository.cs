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
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Product>> GetProductsWithCategory()
        {
            return await _dbContext.Products.Include(x => x.Category).ToListAsync();
        }
    }
}
