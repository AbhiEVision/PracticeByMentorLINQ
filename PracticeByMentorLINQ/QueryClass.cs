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

		public static void QueryOneWithLINQ()
		{
			var test = DataStorage.Customers
				.Join(
					DataStorage.Orders,
					cust => cust.CustomerID,
					ord => ord.CustomerId,
					(cus, ord) => new
					{
						customerID = cus.CustomerID,
						customerName = cus.CustomerName,
						orderId = ord.OrderId,
						orderDate = ord.OrderDate,
						itemID = ord.ItemID
					}
				).Join(
					DataStorage.Items,
					cust => cust.itemID,
					item => item.ItemID,
					(cus, item) => new
					{
						cus.customerID,
						cus.customerName,
						cus.orderId,
						cus.orderDate,
						cus.itemID,
						itemName = item.ItemName,
						itemPrice = item.Price
					}
				).ToList();

			var grouppedList = test.GroupBy(x => (x.customerID, x.orderDate)).ToList();

			var sumofPrice = grouppedList
				.Select(x => new
				{
					custID = x.Select(x => x.customerID),
					totalExpense = x.Sum(x => x.itemPrice),
					orderDate = x.Select(x => x.orderDate)
				})
				.ToList();

			//foreach (var item in grouppedList)
			//{
			//	Console.Write($"cust id : {item.Key.customerID} \t order date : {item.Key.orderDate}");
			//	foreach (var item1 in item)
			//	{
			//		Console.WriteLine($"\t item id : {item1.itemID} \t item price : {item1.itemPrice}");
			//	}
			//}

			var finalmResult = grouppedList.GroupJoin(
					grouppedList,
					test => test.Key,
					test => test.Key,
					(x, y) => new
					{
						x.Key.customerID,
						x.Key.orderDate,
						totalExpese = y.Select(test => test.Select(test1 => test1.itemPrice).Sum(test3 => test3))
					}
			).ToList();

			foreach (var item in finalmResult)
			{
				Console.WriteLine($"customer id : {item.customerID}\t order date : {item.orderDate}");
				foreach (var x in item.totalExpese)
				{
					Console.WriteLine($"Expense : {x}");
				}
			}

			
			//Console.WriteLine("--------------------- order by id and price ---------------------------");
			//foreach (var item in sumofPrice)
			//{
			//	foreach (var item1 in item.d)
			//	{
			//		Console.WriteLine(item1 + "  " + item.totalExpense);
			//	}
			//}

			//Console.WriteLine("---------------------- order by date and price ------------------------------");
			//foreach (var item in sumofPrice)
			//{
			//	foreach (var item1 in item.custID)
			//	{
			//		Console.WriteLine(item1 + "  " + item.totalExpense);
			//	}
			//}
		}

	}
}