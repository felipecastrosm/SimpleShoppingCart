using System;
using ShoppingCart.Data;

namespace ShoppingCart.Steps
{
	public class ProductStep
	{
		private readonly ProductModel _productModel;

		public ProductStep(ProductModel productModel)
		{
			this._productModel = productModel;
		}

		public void Run(ref Domain.ShoppingCart shoppingCart)
		{
			bool isFinished = false;

			while (!isFinished)
			{
				isFinished = this.ReadProduct(ref shoppingCart);
			}
		}

		public bool ReadProduct(ref Domain.ShoppingCart shoppingCart)
		{
			Console.WriteLine("-> Digite o ID do produto que deseja adicionar: ");

			var productIdInput = Console.ReadLine();

			if (String.IsNullOrWhiteSpace(productIdInput))
			{
				Console.WriteLine("Você precisa digitar o id do produto");

				return false;
			}

			int productId;

			var parseSucceeded = Int32.TryParse(productIdInput, out productId);

			if (!parseSucceeded)
			{
				Console.WriteLine("O id do produto deve ser um número inteiro (ex: 123)");

				return false;
			}

			var product = _productModel.GetProductById(productId);

			if (product == null)
			{
				Console.WriteLine("Nenhum produto foi encontrado para o id \"{0}\"", productId);

				return false;
			}

			shoppingCart.Products.Add(product);

			Console.WriteLine("O produto '{0}' foi adicionado!", product.Name);

			return this.AskAddAnother();
		}

		private bool AskAddAnother()
		{
			const string helpMessage = "Você deve digitar 'S' para Sim ou 'n' para Não";

			Console.WriteLine("-> Deseja adicionar outro produto [S/n]?");

			var addAnotherInput = Console.ReadLine();

			if (!String.IsNullOrWhiteSpace(addAnotherInput))
			{
				if (addAnotherInput.ToLower() == "s")
				{
					return true;
				}
				
				if (addAnotherInput.ToLower() == "n")
				{
					return false;
				}
			}

			Console.WriteLine(helpMessage);

			return this.AskAddAnother();
		}
	}
}
