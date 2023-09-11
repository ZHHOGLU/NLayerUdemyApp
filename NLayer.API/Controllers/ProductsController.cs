using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.API.Filters;
using NLayer.Core.DTO_s;
using NLayer.Core.Model;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    
    public class ProductsController : CustomController
    {
        private readonly IMapper _mapper;
        private readonly IProductService _services;

        public ProductsController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            
            _services = productService;
        }
        [HttpGet("GetProductWithCategory")]
        public async Task<IActionResult> GetProductWithCategory() 
        {
            return CreateActionResult(await _services.GetProductWithCategory());
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var products = await _services.GetAllAsync();
            var productsDtos = _mapper.Map<List<ProductDTO>>(products.ToList());
            return CreateActionResult(CustomResponseDTO<List<ProductDTO>>.Success(200, productsDtos));
        }


        [ServiceFilter(typeof(NotFoundFilter<Product>))]

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var products = await _services.GetByIdAsync(id);
            var productsDtos = _mapper.Map<ProductDTO>(products);
            return CreateActionResult(CustomResponseDTO<ProductDTO>.Success(200, productsDtos));
        }

        [HttpPost()]
        public async Task<IActionResult> Save(ProductDTO productDto)
        {
            var products = await _services.AddAsync(_mapper.Map<Product>(productDto));
            var productsDtos = _mapper.Map<ProductDTO>(products);
            return CreateActionResult(CustomResponseDTO<ProductDTO>.Success(201, productsDtos));
        }
        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDTO productDto)
        {
            await _services.UpdateAsync(_mapper.Map<Product>(productDto));
            
            return CreateActionResult(CustomResponseDTO<NoContentDTO>.Success(204));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var products = await _services.GetByIdAsync(id);
            await _services.RemoveAsync(products);
            return CreateActionResult(CustomResponseDTO<NoContentDTO>.Success(204));
        }
    }
}
