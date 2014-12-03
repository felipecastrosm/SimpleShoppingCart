using ShoppingCart.Domain.Enum;
using ShoppingCart.Exceptions;

namespace ShoppingCart.Domain
{
	public class Discount
	{
		public string Code { get; set; }

		public DiscountType Type { get; set; }

		public decimal Amount { get; set; }

		public Discount(string code, string type, decimal amount)
		{
			this.Code = code;
			this.Type = this.GetDiscountTypeEnumValue(type);
			this.Amount = amount;
		}

		public Discount(string code, DiscountType type, decimal amount)
		{
			
		}

		public DiscountType GetDiscountTypeEnumValue(string type)
		{
			switch (type)
			{
				case "fixed":
					return DiscountType.Fixed;
				case "percentage":
					return DiscountType.Percentage;
				default:
					throw new UnknownDiscountTypeException {UnknownType = type};
			}
		}

		public string GetDiscountTypeStringValue(DiscountType type)
		{
			switch (type)
			{
				case DiscountType.Fixed:
					return "fixed";
				case DiscountType.Percentage:
					return "percentage";
				default:
					throw new DiscountTypeNotImplementedException {NotImplementedDiscountType = type};
			}
		}
	}
}
