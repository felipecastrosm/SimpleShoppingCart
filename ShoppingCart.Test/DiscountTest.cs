using NUnit.Framework;
using ShoppingCart.Domain;
using ShoppingCart.Domain.Enum;
using ShoppingCart.Exceptions;

namespace ShoppingCart.Test
{
	[TestFixture]
	public class DiscountTest
	{
		public class GetDiscountTypeEnumValue
		{
			[Test]
			public void GivenValidTypeStringShouldReturnEnumType()
			{
				//Arrange
				const string validType = "fixed";
				var discount = new Discount();

				//Act
				var enumType = discount.GetDiscountTypeEnumValue(validType);

				//Assert
				Assert.That(enumType, Is.TypeOf<DiscountType>());
				Assert.That(enumType, Is.EqualTo(DiscountType.Fixed));
			}

			[Test]
			public void GivenInvalidTypeStringShouldThrowUnknownDiscountTypeException()
			{
				//Arrange
				const string invalidType = "invalidType";
				var discount = new Discount();

				//Act

				//Assert
				Assert.Throws<UnknownDiscountTypeException>(() => discount.GetDiscountTypeEnumValue(invalidType));
			}
		}

		public class GetDiscountTypeStringValue
		{
			[Test]
			public void GivenValidEnumTypeShouldReturnString()
			{
				//Arrange
				const DiscountType validEnumType = DiscountType.Percentage;
				var discount = new Discount();

				//Act
				var returnString = discount.GetDiscountTypeStringValue(validEnumType);

				//Assert
				Assert.That(returnString, Is.EqualTo("percentage"));
			}
		}
	}
}
