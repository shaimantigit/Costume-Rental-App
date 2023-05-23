using AutoMapper;
//using FinalMockProject.BLL;
using FinalMockProject.DAL;
using FinalMockProject.DAL.Interface;
using FinalMockProject.Models;
using FinalMockProject.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalMockProject.Controller
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository, IMapper mapper)
        {

            _mapper = mapper;
            _productRepository = productRepository;
        }

        [HttpGet("products")]
        public async Task<IActionResult> GetAllProduct()
        {
            var products = await _productRepository.GetAllAsync();
            var productDtos = _mapper.Map<IEnumerable<ProductDTO>>(products);
            return Ok(productDtos);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var products = await _productRepository.GetByIdAsync(id);
            if (products == null)
                return NotFound();
            var productDtos = _mapper.Map<ProductDTO>(products);
            return Ok(productDtos);
        }
        [HttpPost]
      
        public async Task<IActionResult> CreateProduct(ProductDTO productDto)
        {
            

            var products = _mapper.Map<Product>(productDto);

            await _productRepository.AddAsync(products);
            var createdProductsDto = _mapper.Map<ProductDTO>(products);
            return Ok(createdProductsDto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductDTO productDto)
        {

            var existingProduct = await _productRepository.GetByIdAsync(id);
            if (existingProduct == null)
                return NotFound();

            _mapper.Map(productDto, existingProduct);

            await _productRepository.UpdateAsync(existingProduct);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var existingProduct = await _productRepository.GetByIdAsync(id);
            if (existingProduct == null)
                return NotFound();

            await _productRepository.DeleteAsync(existingProduct);
            return Ok("Product deleted sauccessfully");
        }


    }

    }

