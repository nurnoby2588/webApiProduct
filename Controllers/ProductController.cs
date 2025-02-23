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

        public ProductController(ProductRepository productRepository) { 
        _productRepository = productRepository;
        }

        [HttpGet ("GetProduct")]
        public async Task<IActionResult> GetProductList()
        {
            List<Product> products = await _productRepository.GetProductsList();
            return Ok(products);
        }
    }
}
