using System;
using ShoppingCart.Domain.Enum;

namespace ShoppingCart.Exceptions
{
	public class DiscountTypeNotImplementedException : ApplicationException
	{
		public DiscountType NotImplementedDiscountType { get; set; }
	}
}
