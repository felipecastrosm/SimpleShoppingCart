using System.Collections.Generic;
using NUnit.Framework;
using ShoppingCart.Domain;

namespace ShoppingCart.Test
{
	[TestFixture]
    public class ShoppingCartTest
    {
		public class GetTotalPrice
		{
			[Test]
			public void GivenProductSetGetTotalPrice()
			{
				//Arrange
				var products = new List<Product>
				{
					new Product(123, "Fake Product 1", 13.75M),
					new Product(456, "Fake Product 2", 14.01M)
				};

				var shoppingCart = new Domain.ShoppingCart(products);

				//Act
				var totalPrice = shoppingCart.GetTotalPrice();

				//Assert
				Assert.That(totalPrice, Is.EqualTo(27.76M));
			}
		}

		public class GetDiscountValue
		{
			[Test]
			public void GivenProductSetAndFixedDiscountGetDiscountValue()
			{
				//Arrange
				var products = new List<Product>
				{
					new Product(123, "Fake Product 1", 15M),
					new Product(456, "Fake Product 2", 35M)
				};

				var discount = new Discount("ABC", "fixed", 10M);

				var shoppingCart = new Domain.ShoppingCart(products) { Discount = discount };

				//Act
				var discountValue = shoppingCart.GetDiscountValue();

				//Assert
				Assert.That(discountValue, Is.EqualTo(10M));
			}

			[Test]
			public void GivenProductSetAndPercentageDiscountGetDiscountValue()
			{
				//Arrange
				var products = new List<Product>
				{
					new Product(123, "Fake Product 1", 15M),
					new Product(456, "Fake Product 2", 35M)
				};

				var discount = new Discount("ABC", "percentage", 10M);

				var shoppingCart = new Domain.ShoppingCart(products) { Discount = discount };

				//Act
				var discountValue = shoppingCart.GetDiscountValue();

				//Assert
				Assert.That(discountValue, Is.EqualTo(5M));
			}

			[Test]
			public void GivenProductSetAndNullDiscountGetDiscountValue()
			{
				//Arrange
				var products = new List<Product>
				{
					new Product(123, "Fake Product 1", 15M),
					new Product(456, "Fake Product 2", 35M)
				};

				var shoppingCart = new Domain.ShoppingCart(products);

				//Act
				var discountValue = shoppingCart.GetDiscountValue();

				//Assert
				Assert.That(discountValue, Is.EqualTo(0));
			}
		}

		public class GetOrder
		{
			[Test]
			public void GivenProductSetAndDiscountGetOrder()
			{
				//Arrange
				var products = new List<Product>
				{
					new Product(123, "Fake Product 1", 15M),
					new Product(456, "Fake Product 2", 35M)
				};

				var discount = new Discount("ABC", "percentage", 10M);

				var shoppingCart = new Domain.ShoppingCart(products) { Discount = discount };

				//Act
				var order = shoppingCart.GetOrder();

				//Assert
				Assert.That(order.Products, Is.EquivalentTo(products));
				Assert.That(order.DiscountValue, Is.EqualTo(5M));
				Assert.That(order.Total, Is.EqualTo(45M));
			}
		}
    }
}
