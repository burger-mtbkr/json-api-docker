using Microsoft.Extensions.Logging;
using Product.Json.Api.Models;
using Product.Json.Api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Json.Api.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductService> _logger;
        public ProductService(IProductRepository productRepository, ILogger<ProductService> logger)
        {
            _logger = logger;
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public IEnumerable<ProductModel> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public IEnumerable<ProductModel> GetProduct(string id)
        {
            return _productRepository.GetProducts().Where(p => p.Id == id);
        }

        public IEnumerable<ProductModel> GetProductByName(string name)
        {
            return _productRepository.GetProducts().Where(p => p.Name == name);
        }

        public IEnumerable<ProductModel> GetProductByCategory(string categoryName)
        {
             return _productRepository.GetProducts().Where(p => p.Category == categoryName);
        }

        public async Task<bool> CreateProduct(ProductModel product) 
        {
            return await _productRepository.CreateProduct(product);           
        }

        public async Task<bool> UpdateProduct(ProductModel product) 
        {
            return await _productRepository.UpdateProduct(product);           
        }

        public async Task<bool> DeleteProduct(string id)
        {
             return await _productRepository.DeleteProduct(id);           
        }

        public async Task<long> DeleteProducts(string[] productIds)
        {
            return await _productRepository.DeleteProducts(productIds);           
        }    
    }
}
