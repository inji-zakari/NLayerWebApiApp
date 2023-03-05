using NLayerWebApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerWebApi.Core.DTOs
{
    public class CategoryWithProductsDto : CategoryDto
    {
        public List<Product> Products { get; set; }
    }
}
