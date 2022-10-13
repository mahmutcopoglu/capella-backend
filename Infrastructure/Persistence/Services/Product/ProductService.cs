using Application.DataTransferObject;
using Application.Repositories.ProductAbstract;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository, IMapper mapper)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            _mapper = mapper;
        }

       
        public async Task<bool> saveProduct(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            product.Code = Guid.NewGuid().ToString();
            var result = await _productWriteRepository.AddAsync(product);
            if (!result)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        public async Task<List<Product>> productList()
        {
            List<Product> products = await _productReadRepository.GetAll().ToListAsync();
            return products;
        }
        public async Task<Product> getProductById(int productId)
        {
            var product = await _productReadRepository.GetByIdAsync(productId);
            return product;

        }       
    }
}
