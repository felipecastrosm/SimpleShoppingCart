using System.Collections.Generic;
using System.Linq;
using ShoppingCart.Domain.Enum;
using ShoppingCart.Exceptions;

namespace ShoppingCart.Domain
{
	public class ShoppingCart
	{
		public List<Product> Products { get; set; }

		public Discount Discount { get; set; }

		public ShoppingCart()
		{
			this.Products = new List<Product>();
		}

		public ShoppingCart(List<Product> products)
		{
			this.Products = products;
		}

		public decimal GetTotalPrice()
		{
			var totalPrice = this.Products.Sum(p => p.Price);

			return totalPrice;
		}

		public decimal GetDiscountValue()
		{
			if (this.Discount == null)
			{
				return 0;
			}

			decimal discountValue;

			switch (this.Discount.Type)
			{
				case DiscountType.Fixed:
					discountValue = this.Discount.Amount;
					break;
				case DiscountType.Percentage:
					var totalPrice = this.GetTotalPrice();
					discountValue = (totalPrice/100)*this.Discount.Amount;
					break;
				default:
					throw new DiscountTypeNotImplementedException {NotImplementedDiscountType = this.Discount.Type};
			}

			return discountValue;
		}

		public Order GetOrder()
		{
			var discountValue = this.GetDiscountValue();

			var subtotal = this.GetTotalPrice();

			var total = subtotal - discountValue;

			var order = new Order {DiscountValue = discountValue, Total = total, Products = this.Products};

			return order;
		}
	}
}
