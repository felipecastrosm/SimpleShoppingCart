using System;

namespace ShoppingCart.Exceptions
{
	public class UnknownDiscountTypeException : ApplicationException
	{
		public string UnknownType { get; set; }
	}
}
