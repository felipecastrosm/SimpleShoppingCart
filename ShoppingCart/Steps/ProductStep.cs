using System;
using System.Linq;
using ShoppingCart.Data;

namespace ShoppingCart.Steps
{
	public class ProductStep
	{
		private readonly ProductModel _productModel;

		private readonly Domain.ShoppingCart _shoppingCart;

		public ProductStep(ProductModel productModel, Domain.ShoppingCart shoppingCart)
		{
			this._productModel = productModel;
			this._shoppingCart = shoppingCart;
		}

		public void Run()
		{
			bool isFinished = false;

			while (!isFinished)
			{
				isFinished = this.ReadProduct();
			}
		}

		public bool ReadProduct()
		{
			int productId;

			if (!this.TryReadProductId(out productId))
			{
				return false;
			}

			if (productId == 0)
			{
				if (this._shoppingCart.Products.Any())
				{
					return true;
				}

				Console.WriteLine("!! É necessário adicionar ao menos um produto em seu carrinho");

				return false;
			}

			var product = _productModel.GetProductById(productId);

			if (product == null)
			{
				Console.WriteLine("!! Nenhum produto foi encontrado para o id '{0}'", productId);

				return false;
			}

			if (this._shoppingCart.Products.Any(p => p.Id == product.Id))
			{
				Console.WriteLine("!! O produto '{0}' já está no carrinho", product.Name);

				return false;
			}

			this._shoppingCart.Products.Add(product);

			Console.WriteLine();
			Console.WriteLine("O produto '{0}' foi adicionado!", product.Name);
			Console.WriteLine();

			return this.AskAddAnother();
		}

		private bool TryReadProductId(out int productId)
		{
			productId = 0;

			Console.Write("-> Digite o ID do produto que deseja adicionar: ");

			var productIdInput = Console.ReadLine();

			if (String.IsNullOrWhiteSpace(productIdInput))
			{
				Console.WriteLine("!! Você precisa digitar o id do produto");

				return false;
			}

			var parseSucceeded = Int32.TryParse(productIdInput, out productId);

			if (!parseSucceeded)
			{
				Console.WriteLine("!! O id do produto deve ser um número inteiro (ex: 123)");

				return false;
			}

			return true;
		}

		private bool AskAddAnother()
		{
			const string helpMessage = "!! Você deve digitar 'S' para Sim ou 'n' para Não";

			Console.Write("-> Deseja adicionar outro produto [S/n]? ");

			var addAnotherInput = Console.ReadLine();

			if (!String.IsNullOrWhiteSpace(addAnotherInput))
			{
				if (addAnotherInput.ToLower() == "s")
				{
					return false;
				}
				
				if (addAnotherInput.ToLower() == "n")
				{
					return true;
				}
			}

			Console.WriteLine(helpMessage);

			return this.AskAddAnother();
		}
	}
}
