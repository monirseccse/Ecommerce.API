using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Domain.Specification;
using Ecommerce.API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepository<Product> _productrepository;
        private readonly IMapper _mapper;

        public ProductController(IRepository<Product> productrepository, IMapper mapper)
        {
            _productrepository = productrepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProducttoReturnDto>>> GetProducts()
        {
            var spec = new ProductswithBrandAndTypeSpecification();
            var products = await _productrepository.GetAllSpecAsync(spec);

            return Ok(_mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProducttoReturnDto>>
                (products));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProducttoReturnDto>> GetProduct(int id)
        {
            var spec = new ProductswithBrandAndTypeSpecification(id);

            var product = await _productrepository.GetByIdwithSpecAsync(spec);

            return _mapper.Map<Product, ProducttoReturnDto>(product);
        }
    }
}
