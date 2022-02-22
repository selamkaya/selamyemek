using SelamYemek.Common;
using SelamYemek.Service.Base;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SelamYemek.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        /// <summary>
        /// Get Category by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Response</returns>
        /// <response code="200">Response</response>
        [HttpGet("/[controller]/{id}")]
        public async Task<ActionResult> Get(string id)
        {
            var result = await _categoryService.Read(id);
            return StatusCode(result.Code, result);
        }

        /// <summary>
        /// Get All Category
        /// </summary>
        /// <returns>Response</returns>
        /// <response code="200">Response</response>
        [HttpPost()]
        public async Task<ActionResult> Post(CategoryFilter categoryFilter)
        {
            var result = await _categoryService.Read(categoryFilter);
            return StatusCode(result.Code, result);
        }

        /// <summary>
        /// Insert category
        /// </summary>       
        /// <param name="category">Category</param>
        /// <returns>Response</returns>
        /// <response code="201">Response</response>
        [HttpPut()]
        public async Task<ActionResult> Put(Category category)
        {
            var result = await _categoryService.Create(category);
            return StatusCode(result.Code, result);
        }

        /// <summary>
        /// Delete category
        /// </summary>       
        /// <param name="id"></param>
        /// <returns>Response</returns>
        /// <response code="200">Response</response>
        [HttpDelete()]
        public async Task<ActionResult> Delete(string id)
        {
            var result = await _categoryService.Delete(id);
            return StatusCode(result.Code, result);
        }
    }
}
