using SelamYemek.Common;
using SelamYemek.Service.Base;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SelamYemek.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Get Product by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Response</returns>
        /// <response code="200">Response</response>
        [HttpGet("/[controller]/{id}")]
        public async Task<ActionResult> Get(string id)
        {
            var result = await _productService.Read(id);
            return StatusCode(result.Code, result);
        }

        /// <summary>
        /// Get All Product
        /// </summary>
        /// <returns>Response</returns>
        /// <response code="200">Response</response>
        [HttpPost()]
        public async Task<ActionResult> Post(ProductFilter productFilter)
        {
            var result = await _productService.Read(productFilter);
            return StatusCode(result.Code, result);
        }

        /// <summary>
        /// Insert product
        /// </summary>       
        /// <param name="category">Category</param>
        /// <returns>Response</returns>
        /// <response code="201">Response</response>
        [HttpPut()]
        public async Task<ActionResult> Put(Product product)
        {
            var result = await _productService.Create(product);
            return StatusCode(result.Code, result);
        }

        /// <summary>
        /// Delete product
        /// </summary>       
        /// <param name="id"></param>
        /// <returns>Response</returns>
        /// <response code="201">Response</response>
        [HttpDelete()]
        public async Task<ActionResult> Delete(string id)
        {
            var result = await _productService.Delete(id);
            return StatusCode(result.Code, result);
        }
    }
}
