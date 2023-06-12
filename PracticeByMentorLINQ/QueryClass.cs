namespace PracticeByMentorLINQ
{
	public class QueryClass
	{
		public record OrdDetail(int ordId, DateOnly ordDate, int itemID, int itemPrice);


		public record countByPrice(int count, int totalPrice);
		public static void FirstQuery()
		{
			// var test = (from ord in DataStorage.Orders
			//     join item in DataStorage.Items
			//         on ord.ItemID equals item.ItemID
			//     select new
			//     {
			//         ord.OrderId,
			//         ord.OrderDate,
			//         ord.CustomerId,
			//         item.ItemID,
			//         item.ItemName,
			//         item.Price
			//     }).ToList();

			var test = DataStorage.Orders.Join(
					DataStorage.Items,
					ord => ord.ItemID,
					item => item.ItemID,
					(ord, item) => new
					{
						ord.OrderId,
						ord.OrderDate,
						ord.CustomerId,
						item.ItemID,
						item.ItemName,
						item.Price
					}
				)
				.GroupBy(x => (x.CustomerId, x.OrderDate))
				.ToList();

			Dictionary<int, List<OrdDetail>> ordOfCustomer = new();


			//foreach (var item in test)
			//{
			//	ordOfCustomer.Add(item.Key, new List<OrdDetail>());
			//}

			//foreach (var item in test)
			//{
			//	foreach (var item1 in item)
			//	{
			//		ordOfCustomer[item.Key].Add(new OrdDetail(item1.OrderId, item1.OrderDate, item1.ItemID, item1.Price));

			//	}
			//}

			Dictionary<TestClass, countByPrice> a1 = new Dictionary<TestClass, countByPrice>();

			foreach (var item in test)
			{
				TestClass x = new(item.Key.CustomerId, item.Key.OrderDate);
				int a = 0;
				int count = 0;
				foreach (var item1 in item)
				{
					a += item1.Price;
					count++;
				}
				a1.Add(x, new countByPrice(count, a));
			}


			//        Dictionary<int, List<Dictionary<DateOnly, int>>> person_date_price = new Dictionary<int, List<Dictionary<DateOnly, int>>>();

			//        foreach (var item in ordOfCustomer)
			//        {
			//person_date_price.Add(item.Key, new());
			//        }

			//foreach (var item in a1)
			//{
			//	Console.WriteLine(item.Key.custID + "  " + item.Key.ordDate);
			//}

			//foreach (var item in test)
			//{
			//	foreach (var item1 in item)
			//	{
			//		a1[new TestClass(item.Key.CustomerId, item.Key.OrderDate)].Add(item1.Price);
			//	}
			//}

			foreach (var item in a1)
			{
				Console.WriteLine(item.Key.custID + "  " + item.Key.ordDate + "   " + item.Value.count + "  " + item.Value.totalPrice);


				Console.WriteLine("------------------------------------");
			}












			//foreach (var data in test)
			//{

			//	Console.WriteLine(data.Key);
			//	foreach (var VARIABLE in data)
			//	{
			//		Console.WriteLine(VARIABLE.OrderId);
			//	}

			//	Console.WriteLine("------------------------------------------------");
			//}

		}
	}
}