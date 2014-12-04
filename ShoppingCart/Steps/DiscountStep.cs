using System;
using ShoppingCart.Data;
using ShoppingCart.Domain;

namespace ShoppingCart.Steps
{
	public class DiscountStep
	{
		private readonly DiscountModel _discountModel;

		private readonly Domain.ShoppingCart _shoppingCart;

		public DiscountStep(DiscountModel discountModel, Domain.ShoppingCart shoppingCart)
		{
			this._discountModel = discountModel;
			this._shoppingCart = shoppingCart;
		}

		public void Run()
		{
			this.ReadDiscount();
		}

		private void ReadDiscount()
		{
			Console.Write("-> Deseja adicionar um cupom de desconto [S/n]? ");

			var discountOptInput = Console.ReadLine();

			if (!String.IsNullOrWhiteSpace(discountOptInput))
			{
				if(discountOptInput.ToLower() == "n")
				{
					return;
				}
				
				if (discountOptInput.ToLower() == "s")
				{
					this._shoppingCart.Discount = this.HandleDiscountUtilization();

					return;
				}
			}

			Console.WriteLine("!! Você deve digitar 'S' para Sim ou 'n' para Não");

			this.ReadDiscount();
		}

		private Discount HandleDiscountUtilization()
		{
			var discountCode = this.ReadDiscountCode();

			if (discountCode == "0")
			{
				return null;
			}

			var discount = _discountModel.GetDiscountByCode(discountCode);

			if (discount == null)
			{
				Console.WriteLine("!! Nenhum desconto foi encontrado para o código \"{0}\"", discountCode);

				return this.HandleDiscountUtilization();
			}

			Console.WriteLine();
			Console.WriteLine("O desconto foi aplicado!");

			return discount;
		}

		private string ReadDiscountCode()
		{
			Console.Write("-> Digite o código do cupom: ");

			var discountCodeInput = Console.ReadLine();

			if (String.IsNullOrWhiteSpace(discountCodeInput))
			{
				Console.WriteLine("!! Você precisa digitar o código de desconto");

				return this.ReadDiscountCode();
			}

			return discountCodeInput;
		}
	}
}
