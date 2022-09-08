using JsonFlatFileDataStore;
using Microsoft.Extensions.Logging;
using Product.Json.Api.Infrastructure;
using Product.Json.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Json.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDataStore _db;
        private readonly ILogger<ProductRepository> _logger;

        private IDocumentCollection<ProductModel> Collection() => _db.GetCollection<ProductModel>("Items");

        public ProductRepository(DatabaseSettings settings, ILogger<ProductRepository> logger)
        {
            _logger = logger;
            _db = new DataStore(
           settings.FilePath,
           // Enables live updates to the provided json file by reading the file each time, turns caching on or off.
           reloadBeforeGetCollection: settings.LiveReload,
           keyProperty: "Id");
        }

        public IEnumerable<ProductModel> GetProducts()
        {
            var collection = Collection();
            return collection.AsQueryable();
        }

        public ProductModel GetProduct(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> CreateProduct(ProductModel product)
        {
            var id = Guid.NewGuid().ToString().ToUpper();
            await Collection().InsertOneAsync(product with
            {
                Id = id              
            });

            return true;
        }

        public Task<bool> UpdateProduct(ProductModel p) => Collection().UpdateOneAsync(p.Id.ToUpper(), p with { Id = p.Id.ToUpper() });

        public Task<bool> DeleteProduct(string id) => Collection().DeleteOneAsync(id.ToUpper());

        public async Task<long> DeleteProducts(string[] productIds)
        {
            var collection = Collection();
            var originalCount = collection.Count;
            var success = await collection.DeleteManyAsync(product => productIds.Contains(product.Id.ToUpper()));

            if (success)
            {
                return productIds.Length;
            }

            _logger.LogError($"Failed to delete some id's: {string.Join(", ", productIds)}");
            return originalCount - collection.Count;
        }      
    }
}
