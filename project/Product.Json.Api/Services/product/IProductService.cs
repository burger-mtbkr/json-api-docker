using System;
using Product.Json.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.Json.Api.Services
{
    public interface IProductService
    {
        IEnumerable<ProductModel> GetProducts();
        IEnumerable<ProductModel> GetProduct(string id);
        IEnumerable<ProductModel> GetProductByName(string name);
        IEnumerable<ProductModel> GetProductByCategory(string categoryName);
        Task<bool> CreateProduct(ProductModel product);
        Task<bool> UpdateProduct(ProductModel product);
        Task<bool> DeleteProduct(string id);
        Task<long> DeleteProducts(string[] itemIds);
    }
}
