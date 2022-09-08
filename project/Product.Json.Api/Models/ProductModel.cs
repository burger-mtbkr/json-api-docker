namespace Product.Json.Api.Models
{
	public record ProductModel
	{	
		public string Id { get; set; }
		public string Name { get; set; }
		public string Category { get; set; }
		public decimal Price { get; set; }
	}
}
