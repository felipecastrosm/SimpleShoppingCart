using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
					new Product {Price = 13.75M},
					new Product {Price = 14.01M}
				};

				var shoppingCart = new Domain.ShoppingCart(products);

				//Act
				var totalPrice = shoppingCart.GetTotalPrice();

				//Assert
				Assert.That(totalPrice, Is.EqualTo(27.76M));
			}
		}
    }
}
