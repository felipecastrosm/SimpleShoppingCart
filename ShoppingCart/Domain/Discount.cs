using ShoppingCart.Domain.Enum;
using ShoppingCart.Exceptions;

namespace ShoppingCart.Domain
{
	public class Discount
	{
		public string Code { get; set; }

		public DiscountType Type { get; set; }

		public decimal Amount { get; set; }

		public Discount()
		{
			
		}

		public Discount(string code, string type, decimal amount)
			: this(code, amount)
		{
			this.Type = this.GetDiscountTypeEnumValue(type);
		}

		public Discount(string code, DiscountType type, decimal amount)
			: this(code, amount)
		{
			this.Type = type;
		}

		private Discount(string code, decimal amount)
		{
			this.Code = code;
			this.Amount = amount;
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
