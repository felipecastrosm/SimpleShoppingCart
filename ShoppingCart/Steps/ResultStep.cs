using System;
using ShoppingCart.ExtensionMethods;

namespace ShoppingCart.Steps
{
	public class ResultStep
	{
		private readonly Domain.ShoppingCart _shoppingCart;

		public ResultStep(Domain.ShoppingCart shoppingCart)
		{
			this._shoppingCart = shoppingCart;
		}

		public void Run()
		{
			this.PrintResult();
		}

		private void PrintResult()
		{
			var order = this._shoppingCart.GetOrder();

			Console.WriteLine();

			foreach (var product in order.Products)
			{
				Console.CursorLeft = 2;
				Console.WriteLine("{0,-3} {1,-45} {2,13:C}", product.Id, product.Name.Truncate(45), product.Price);
			}

			Console.WriteLine();
			Console.CursorLeft = 2;
			Console.WriteLine("Descontos:{0,53:C}", order.DiscountValue*-1);
			Console.CursorLeft = 2;
			Console.WriteLine("TOTAL:{0,57:C}", order.Total);
		}
	}
}
