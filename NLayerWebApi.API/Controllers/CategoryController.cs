using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerWebApi.Core.IServices;

namespace NLayerWebApi.API.Controllers
{
    public class CategoryController : CustomBaseController
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet("[action]/{categoryId}")]
        public async Task<IActionResult> GetCategoryByIdWithProducts(int categoryId)
        {
            return CreateActionResult(await _service.GetSingleCategoryByIdWithProduct(categoryId));
        }
    }
}
