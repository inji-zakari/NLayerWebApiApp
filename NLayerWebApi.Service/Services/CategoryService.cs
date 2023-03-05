using AutoMapper;
using NLayerWebApi.Core.DTOs;
using NLayerWebApi.Core.Entities;
using NLayerWebApi.Core.IRepositories;
using NLayerWebApi.Core.IServices;
using NLayerWebApi.Core.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerWebApi.Service.Services
{
    public class CategoryService : GenericService<Category>, ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;
        public CategoryService(IGenericRepository<Category> repository, IUnitOfWork unitOfWork, ICategoryRepository categoryRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _repository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<CategoryWithProductsDto>> GetSingleCategoryByIdWithProduct(int categoryId)
        {
            var category = await _repository.GetCategoryByIdWithProducts(categoryId);
            var categoryDto = _mapper.Map<CategoryWithProductsDto>(category);
            return CustomResponseDto<CategoryWithProductsDto>.Success(200, categoryDto);
        }
    }
}
