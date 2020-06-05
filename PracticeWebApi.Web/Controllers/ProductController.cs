using Microsoft.AspNetCore.Mvc;
using PracticeWebApi.CommonClasses.Products;
using PracticeWebApi.Services;
using System.Threading.Tasks;

namespace PracticeWebApi.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("/products")]
        public async Task<IActionResult> AddProduct([FromBody]Product product)
        {
            var addedProduct = await _productService.AddProduct(product);
            return Ok(addedProduct);
        }

        [HttpPost("/products/{productId}")]
        public async Task<IActionResult> ActivateProduct([FromRoute]string productId)
        {
            await _productService.ActivateProduct(productId);
            return Ok();
        }

        [HttpPut("/products")]
        public async Task<IActionResult> UpdateProduct([FromBody]Product product)
        {
            await _productService.UpdateProduct(product);
            return Ok();
        }

        [HttpDelete("/products/{productId}")]
        public async Task<IActionResult> DeactivateProduct([FromRoute]string productId)
        {
            await _productService.DeactiveProduct(productId);
            return Ok();
        }

        [HttpGet("/products/{productId}")]
        public async Task<IActionResult> FindProductById([FromRoute]string productId)
        {
            var product = await _productService.FindProductById(productId);
            return Ok(product);
        }

        [HttpGet("/products/group/{groupId}")]
        public async Task<IActionResult> GetProductsByGroupId([FromRoute]string groupId)
        {
            var products = await _productService.GetProductsByGroupId(groupId);
            return Ok(products);
        }
    }
}