namespace ShoppingCart.ExtensionMethods
{
	public static class StringExtensions
	{
		/// <summary>
		/// Truncates a string to a fixed length adding an optional suffix
		/// </summary>
		/// <param name="originalString">The string to be truncated</param>
		/// <param name="maxSize">The length it should be truncated to</param>
		/// <param name="suffix">The optional suffix (Defaults to "...")</param>
		/// <returns></returns>
		public static string Truncate(this string originalString, int maxSize, string suffix = "...")
		{
			var workString = originalString.Trim();

			if (originalString.Length <= maxSize)
			{
				return originalString;
			}

			var usableLength = maxSize - suffix.Length;

			var finalString = workString.Substring(0, usableLength) + suffix;

			return finalString;
		}
	}
}
