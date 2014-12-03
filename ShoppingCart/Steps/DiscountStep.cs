using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.Data;

namespace ShoppingCart.Steps
{
	public class DiscountStep
	{
		private readonly DiscountModel _discountModel;

		public DiscountStep(DiscountModel discountModel)
		{
			this._discountModel = discountModel;
		}

		public void Run(ref Domain.ShoppingCart shoppingCart)
		{

		}
	}
}
