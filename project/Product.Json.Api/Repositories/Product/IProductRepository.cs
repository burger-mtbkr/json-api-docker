using Product.Json.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.Json.Api.Repositories
{
    public interface IProductRepository
    {
        Task<bool> CreateProduct(ProductModel product);
        IEnumerable<ProductModel> GetProducts();
        ProductModel GetProduct(string id);
        Task<bool> UpdateProduct(ProductModel product);
        Task<bool> DeleteProduct(string id);
        Task<long> DeleteProducts(string[] itemIds);
    }
}
