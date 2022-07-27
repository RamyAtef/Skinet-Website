using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Skinet.Core.Entities;
using Skinet.Core.Interfaces;
using Skinet.Infrastructure.Data;

namespace Skinet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("Products")]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts()
        {
            var products= await _repository.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _repository.GetProductByIdAsync(id);

            return Ok(product);
        }

        [HttpGet("Brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            var brands = await _repository.GetProductBrandsAsync();
            return Ok(brands);
        }

        //[HttpGet("{id}")]
        //public async Task<ActionResult<ProductBrand>> GetProductBrandById(int id)
        //{
        //    var brand = await _repository.GetProductBrandByIdAsync(id);

        //    return Ok(brand);
        //}

        [HttpGet("Types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            var types = await _repository.GetProductTypesAsync();
            return Ok(types);
        }

        //[HttpGet("{id}")]
        //public async Task<ActionResult<ProductType>> GetProductTypeById(int id)
        //{
        //    var type = await _repository.GetProductTypeByIdAsync(id);

        //    return Ok(type);
        //}
    }
}
