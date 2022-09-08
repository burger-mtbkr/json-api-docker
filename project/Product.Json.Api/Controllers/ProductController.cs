using Product.Json.Api.Models;
using Product.Json.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Product.Json.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;
		private readonly ILogger<ProductController> _logger;

		public ProductController(IProductService productService, ILogger<ProductController> logger)
		{
			_productService = productService ?? throw new ArgumentNullException(nameof(productService));

			_logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

		[HttpGet]
		[ProducesResponseType(typeof(IEnumerable<ProductModel>), (int)HttpStatusCode.OK)]
		public ActionResult<IEnumerable<ProductModel>> GetProducts()
		{
			var products = _productService.GetProducts();
			return Ok(products);
		}

		[HttpGet("{id}", Name = nameof(GetProductById))]
		[ProducesResponseType((int)HttpStatusCode.NotFound)]
		[ProducesResponseType(typeof(ProductModel), (int)HttpStatusCode.OK)]
		public ActionResult<ProductModel> GetProductById(string id)
		{
			var product = _productService.GetProduct(id);

            if (product == null)
			{
				_logger.LogError($"Product with id: {id}, not found.");
				return NotFound();
			}

			return Ok(product);
		}

		[Route("[action]/{category}", Name = nameof(GetProductByCategory))]
		[HttpGet]
		[ProducesResponseType(typeof(IEnumerable<ProductModel>), (int)HttpStatusCode.OK)]
		public ActionResult<IEnumerable<ProductModel>> GetProductByCategory(string category)
		{
			var products = _productService.GetProductByCategory(category);
			return Ok(products);
		}

        [Route("[action]/{name}", Name = nameof(GetProductByName))]
		[HttpGet]
		[ProducesResponseType(typeof(IEnumerable<ProductModel>), (int)HttpStatusCode.OK)]
		public ActionResult<IEnumerable<ProductModel>> GetProductByName(string name)
		{
			var products = _productService.GetProductByName(name);
			return Ok(products);
		}

		[HttpPost]
		[ProducesResponseType(typeof(ProductModel), (int)HttpStatusCode.Created)]
		public async Task<ActionResult<ProductModel>> CreateProduct([FromBody] ProductModel product)
		{
			await _productService.CreateProduct(product); 
			return CreatedAtRoute(nameof(GetProductById), new { id = product.Id }, product);
		}

		[HttpPut]
		[ProducesResponseType(typeof(ProductModel), (int)HttpStatusCode.NoContent)]
		public async Task<IActionResult> UpdateProduct([FromBody] ProductModel product)
		{
            await _productService.UpdateProduct(product);
            return NoContent();
		}

		[HttpDelete("{id}", Name = nameof(DeleteProduct))]
		[ProducesResponseType(typeof(ProductModel), (int)HttpStatusCode.NoContent)]
		public async Task<IActionResult> DeleteProduct(string id)
		{
            await _productService.DeleteProduct(id);
            return NoContent();
        }

        [HttpDelete("{ids}", Name = nameof(DeleteProducts))]
		[ProducesResponseType(typeof(ProductModel), (int)HttpStatusCode.NoContent)]
		public async Task<IActionResult> DeleteProducts(string[] ids)
		{
            await _productService.DeleteProducts(ids);
            return NoContent();
        }
	}
}
