using System.Collections.Generic;

namespace ShoppingCart.Domain
{
	public class Order
	{
		public List<Product> Products { get; set; }

		public decimal DiscountValue { get; set; }

		public decimal Total { get; set; }
	}
}
