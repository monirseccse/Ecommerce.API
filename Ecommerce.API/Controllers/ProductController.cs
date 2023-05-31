using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Domain.Specification;
using Ecommerce.API.DTOs;
using Ecommerce.API.Helper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class ProductController : ControllerBase
    {
        private readonly IRepository<Product> _repository;
        private readonly IRepository<ProductBrand> _brandRepository;
        private readonly IRepository<ProductType>_productTypeRepository;
        private readonly IMapper _mapper;

        public ProductController(
            IRepository<Product> repository,
            IMapper mapper,
            IRepository<ProductBrand> brandRepository,
            IRepository<ProductType> productRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _brandRepository = brandRepository;
            _productTypeRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProducttoReturnDto>>> GetProducts(
            [FromQuery] ProductSpecParams specParams)
        {
            var spec = new ProductswithBrandAndTypeSpecification(specParams);
            var countSpec = new ProductWithFilterForCountSpecification(specParams);

            var totalItems = await _repository.CountAsync(countSpec);
            var products = await _repository.GetAllSpecAsync(spec);

           var data =_mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProducttoReturnDto>>
                (products);

            return Ok(new Pagination<ProducttoReturnDto>(
                specParams.PageIndex, specParams.PageSize, totalItems, data));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProducttoReturnDto>> GetProduct(int id)
        {
            var spec = new ProductswithBrandAndTypeSpecification(id);

            var product = await _repository.GetByIdwithSpecAsync(spec);

            return _mapper.Map<Product, ProducttoReturnDto>(product);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<ProductBrand>>GetProductBrand()
        {
           return Ok(await _brandRepository.GetAllAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<ProductType>> GetProductTypes()
        {
            return Ok(await _productTypeRepository.GetAllAsync());
        }
    }
}
