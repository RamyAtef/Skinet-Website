using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Skinet.API.Dtos;
using Skinet.Core.Entities;
using Skinet.Core.Interfaces;
using Skinet.Core.Spacification;

namespace Skinet.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IGenericRepository<ProductBrand> _productBrandRepository;
    private readonly IMapper _mapper;
    private readonly IGenericRepository<Product> _productRepository;
    private readonly IGenericRepository<ProductType> _productTypeRepository;

    public ProductsController(IGenericRepository<Product> productRepository,
        IGenericRepository<ProductType> productTypeRepository, IGenericRepository<ProductBrand> productBrandRepository,
        IMapper mapper)
    {
        _productRepository = productRepository;
        _productTypeRepository = productTypeRepository;
        _productBrandRepository = productBrandRepository;
        _mapper = mapper;
    }

    [HttpGet("Products")]
    public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts()
    {
        var spec = new ProductWithTypesAndBrandsSpecification();

        var products = await _productRepository.ListAsync(spec);

        var productsDto= 
            _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products);

        return Ok(productsDto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
    {
        var spec = new ProductWithTypesAndBrandsSpecification();

        var product = await _productRepository.GetEntityWithSpec(spec);

        var productDto = _mapper.Map<Product, ProductToReturnDto>(product);

        return Ok(productDto);
    }

    [HttpGet("Brands")]
    public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
    {
        var brands = await _productBrandRepository.ListAllAsync();
        return Ok(brands);
    }

    //[HttpGet("{id}")]
    //public async Task<ActionResult<ProductBrand>> GetProductBrandById(int id)
    //{
    //    var brand = await _productBrandRepository.GetByIdAsync(id);

    //    return Ok(brand);
    //}

    [HttpGet("Types")]
    public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
    {
        var types = await _productTypeRepository.ListAllAsync();
        return Ok(types);
    }

    //[HttpGet("{id}")]
    //public async Task<ActionResult<ProductType>> GetProductTypeById(int id)
    //{
    //    var type = await _productTypeRepository.GetByIdAsync(id);

    //    return Ok(type);
    //}
}