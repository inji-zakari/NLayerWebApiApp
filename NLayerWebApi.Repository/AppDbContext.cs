using Microsoft.EntityFrameworkCore;
using NLayerWebApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NLayerWebApi.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)//Bu options-u vermeyimizin esas sebebi database yolunun startup dosyasindan vermeyimiz ucundur.
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature()
            {
                Id = 1,
                Color = "Red",
                Width = 50,
                Height = 100,
                ProductId = 1
            },
            new ProductFeature()
            {
                Id = 2,
                Color = "Blue",
                Width = 50,
                Height = 100,
                ProductId = 1
            });
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }
    }
}
