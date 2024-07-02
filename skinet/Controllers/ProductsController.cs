using API.DTOs;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class ProductsController : BaseAPIController
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<ProductType> _productTypeRepository;
        private readonly IGenericRepository<ProductBrand> _productBrandRepository;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productRepository,
            IGenericRepository<ProductType> productTypeRepository,
            IGenericRepository<ProductBrand> productBrandRepository,
            IMapper mapper) 
        {
            _productRepository = productRepository;
            _productTypeRepository = productTypeRepository;
            _productBrandRepository = productBrandRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductDTO>>> GetProducts() 
        {
            var spec = new ProductsWithTypesAndBrandsSpecification();
            var products= await _productRepository.GetAllWithSpecification(spec);
            return Ok(_mapper
                .Map<IReadOnlyList<Product>,IReadOnlyList<ProductDTO>>(products));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var product= await _productRepository.GetWithSpecification(spec);
            if (product == null)
                return NotFound(new APIResponse(404));
            return _mapper.Map<Product,ProductDTO>(product);
        }
        [HttpGet("brands")]
        public async Task<ActionResult<List<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _productBrandRepository.GetAllAsync());
        }
        [HttpGet("types")]
        public async Task<ActionResult<List<ProductType>>> GetProductTypes()
        {
            return Ok(await _productTypeRepository.GetAllAsync());
        }
    }
}
