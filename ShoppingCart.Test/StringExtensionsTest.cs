using NUnit.Framework;
using ShoppingCart.ExtensionMethods;

namespace ShoppingCart.Test
{
	[TestFixture]
	public class StringExtensionsTest
	{
		public class Truncate
		{
			[Test]
			public void GivenMaxSizeBiggerThanStringLengthShouldReturnOriginalString()
			{
				//Arrange
				const string originalString = "This is the original string"; //Length = 27
				const int maxSize = 50;

				//Act
				var truncatedString = originalString.Truncate(maxSize);

				//Assert
				Assert.That(truncatedString, Is.EqualTo(originalString));
			}

			[Test]
			public void GivenMaxSizeSmallerThanStringLengthShouldReturnTruncatedString()
			{
				//Arrange
				const string originalString = "This is the original string"; //Length = 27
				const int maxSize = 20;

				//Act
				var truncatedString = originalString.Truncate(maxSize);

				//Assert
				Assert.That(truncatedString.Length, Is.EqualTo(maxSize));
			}

			[Test]
			public void GivenSuffixReturnTruncatedStringUsingIt()
			{
				//Arrange
				const string originalString = "This is the original string"; //Length = 27
				const int maxSize = 20;
				const string suffix = "___";

				//Act
				var truncatedString = originalString.Truncate(maxSize, suffix);

				//Assert
				Assert.That(truncatedString.Length, Is.EqualTo(maxSize));
				Assert.That(truncatedString, Is.StringEnding(suffix));
			}
		}
	}
}
