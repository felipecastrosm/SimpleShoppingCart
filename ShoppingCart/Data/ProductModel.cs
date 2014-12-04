using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ShoppingCart.Domain;

namespace ShoppingCart.Data
{
	public class ProductModel
	{
		public Product GetProductById(int id)
		{
			var productsJson = File.ReadAllText("Resources/products.json");

			var products = JsonConvert.DeserializeObject<List<Product>>(productsJson);

			var product = products.SingleOrDefault(p => p.Id == id);

			return product;
		}
	}
}
