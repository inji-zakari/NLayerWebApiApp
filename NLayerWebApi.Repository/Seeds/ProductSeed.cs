using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerWebApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerWebApi.Repository.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(new Product() { Id = 1, Name = "Kitap 1", Price = 15.4M, Stock = 5, CreatedDate = DateTime.Now, CategoryId = 1 }, new Product() { Id = 2, Name = "Kalem 1", Price = 15.2M, Stock = 3, CreatedDate = DateTime.Now, CategoryId = 2 }, new Product() { Id = 3, Name = "Defter 1", Price = 15.8M, Stock = 4, CreatedDate = DateTime.Now, CategoryId = 3 });
        }
    }
}
