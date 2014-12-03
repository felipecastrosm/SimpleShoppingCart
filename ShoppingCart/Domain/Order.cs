using System.Collections.Generic;

namespace ShoppingCart.Domain
{
	public class Order
	{
		public List<Product> Products { get; set; }

		public decimal DiscountValue { get; set; }

		public decimal Total { get; set; }

		public Order()
		{
			this.Products = new List<Product>();
		}

		public Order(List<Product> products)
		{
			this.Products = products;
		}

		public Order(List<Product> products, decimal discountValue, decimal total) : this(products)
		{
			this.DiscountValue = discountValue;
			this.Total = total;
		}
	}
}
