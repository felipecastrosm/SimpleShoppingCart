using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShoppingCart.Domain;

namespace ShoppingCart.Data
{
	public class DiscountModel
	{
		public Discount GetDiscountByCode(string code)
		{
			var discountsJson = File.ReadAllText("/Resources/discounts.json");

			var discounts = JsonConvert.DeserializeObject<List<Discount>>(discountsJson);

			var discount = discounts.SingleOrDefault(d => d.Code == code);

			return discount;
		}
	}
}
