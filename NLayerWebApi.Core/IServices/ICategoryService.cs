using NLayerWebApi.Core.DTOs;
using NLayerWebApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerWebApi.Core.IServices
{
    public interface ICategoryService : IGenericService<Category>
    {
        Task<CustomResponseDto<CategoryWithProductsDto>> GetSingleCategoryByIdWithProduct(int categoryId);
    }
}
