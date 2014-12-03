namespace ShoppingCart.Domain
{
	public class Product
	{
		public readonly int Id;

		public string Name { get; set; }

		public decimal Price { get; set; }

		public Product(int id, string name, decimal price)
		{
			this.Id = id;
			this.Name = name;
			this.Price = price;
		}
	}
}
