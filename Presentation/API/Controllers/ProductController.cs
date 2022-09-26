using Application.DataTransferObject;
using Application.Repositories.ProductAbstract;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;
        private readonly IMapper _mapper;

        public ProductController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository,IMapper mapper)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            _mapper = mapper;
        }

        [HttpPost("/product")]
        public async Task<IActionResult> AddProduct([FromBody] ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            product.Code = Guid.NewGuid().ToString();
            var result = await _productWriteRepository.AddAsync(product);
            if (!result)
            {
                return BadRequest();
            }else
            {
                return Ok(product);
            }
            
        }

        [HttpGet("/products")]
        public async Task<IActionResult> ProductList()
        {
            List<Product> products = await _productReadRepository.GetAll().ToListAsync();
            return Ok(products);
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductById(int productId)
        {
           var product = await _productReadRepository.GetByIdAsync(productId);
           return Ok(product);
           
        }
    }
}
