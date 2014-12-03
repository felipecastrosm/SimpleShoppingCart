using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.Data;
using ShoppingCart.Steps;

namespace ShoppingCart
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("-- Bem-vindo ao Carrinho de Compras!");

			var shoppingCart = new Domain.ShoppingCart();
			var productModel = new ProductModel();
			var discountModel = new DiscountModel();
			var productStep = new ProductStep(productModel);
			var discountStep = new DiscountStep(discountModel);

			productStep.Run(ref shoppingCart);

			discountStep.Run(ref shoppingCart);
		}
	}
}
