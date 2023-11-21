using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Shared.Categories;
using Swashbuckle.AspNetCore.Annotations;

namespace Project.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [SwaggerOperation("returns all categories")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(CategoryResponse))]
        public Task<CategoryResponse.GetIndex> GetIndexAsync([FromQuery] CategoryRequest.GetIndex request)
        {
            return categoryService.GetIndexAsync(request);
        }
    }
}
