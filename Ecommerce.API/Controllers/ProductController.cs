using Domain.Entities;
using Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productrepository;

        public ProductController(IProductRepository productrepository)
        {
            _productrepository = productrepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _productrepository.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet]
        public async Task<ActionResult<Product>>GetProduct(int id)
        {
            return await _productrepository.GetProductByIdAsync(id);
        }
    }
}
