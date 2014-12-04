using System;
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
			var productStep = new ProductStep(productModel, shoppingCart);
			var discountStep = new DiscountStep(discountModel, shoppingCart);
			var resultStep = new ResultStep(shoppingCart);

			productStep.Run();

			discountStep.Run();

			resultStep.Run();

			Console.ReadLine();
		}
	}
}
