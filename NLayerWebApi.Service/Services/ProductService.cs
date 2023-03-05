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
    public class ProductService : GenericService<Product>, IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public ProductService(IGenericRepository<Product> repository, IUnitOfWork unitOfWork, IProductRepository productRepository,IMapper mapper) : base(repository, unitOfWork)
        {
            _repository = productRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductsWithCategory()
        {
            var products = await _repository.GetProductsWithCategory();
            var productsDto = _mapper.Map<List<ProductWithCategoryDto>>(products);
            return CustomResponseDto<List<ProductWithCategoryDto>>.Success(200, productsDto);
        }
    }
}
