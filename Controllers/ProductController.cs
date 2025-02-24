using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webApiProduct.DataAccess;
using webApiProduct.Model;

namespace webApiProduct.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductRepository _productRepository;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ProductRepository productRepository, ILogger<ProductController> logger) { 
        _productRepository = productRepository;
            _logger = logger;
        }

        [HttpGet ("GetProduct")]
        public async Task<IActionResult> GetProductList()
        {
            List<Product> products = await _productRepository.GetProductsList();
            return Ok(products);
        }

        [HttpPost("addProduct")]
        public async Task<IActionResult> addProduct([FromBody] Product request)
        {
            bool result = await _productRepository.AddProduct(request);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("test")]
        public OkObjectResult Test()
        {
            try
            {
                int a = Convert.ToInt32("dfs");
                return Ok(200);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error");
                return Ok(400);
            }
        }

    }
}
