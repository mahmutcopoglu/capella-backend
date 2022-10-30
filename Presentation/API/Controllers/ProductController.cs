using API.Filters;
using Application.DataTransferObject;
using Application.Repositories.ProductAbstract;
using Application.Services;
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
        private readonly IProductService _productService;
       

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("/product")]
        [ServiceFilter(typeof(CustomAuthorizationFilter)), PermissionAttribute("product_added", "product_deleted")]
        public async Task<IActionResult> AddProduct([FromBody] ProductDto productDto)
        {
            var result = await _productService.saveProduct(productDto);
            if (!result)
            {
                return BadRequest();
            }else
            {
                return Ok(true);
            }
            
        }

        [HttpGet("/products")]
        public async Task<IActionResult> ProductList()
        {
            List<Product> products = await _productService.productList();
            return Ok(products);
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductById(int productId)
        {
            var product = await _productService.getProductById(productId);
            return Ok(product);
           
        }
    }
}
