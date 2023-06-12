namespace PracticeByMentorLINQ
{
	public class DataStorage
	{
		public static List<Item> Items = new List<Item>();
		public static List<CustomerDetails> Customers = new List<CustomerDetails>();
		public static List<OrderDetails> Orders = new List<OrderDetails>();

		static DataStorage()
		{
			Items.Add(new Item() { ItemID = 1001, ItemName = "i1", Price = 500 });
			Items.Add(new Item() { ItemID = 1002, ItemName = "i2", Price = 600 });
			Items.Add(new Item() { ItemID = 1003, ItemName = "i3", Price = 400 });
			Items.Add(new Item() { ItemID = 1004, ItemName = "i4", Price = 300 });
			Items.Add(new Item() { ItemID = 1005, ItemName = "i5", Price = 900 });


			Customers.Add(new CustomerDetails() { CustomerID = 101, CustomerName = "Customer1" });
			Customers.Add(new CustomerDetails() { CustomerID = 102, CustomerName = "Customer2" });
			Customers.Add(new CustomerDetails() { CustomerID = 103, CustomerName = "Customer3" });

			Orders.Add(new OrderDetails() { OrderId = 5001, CustomerId = 101, ItemID = 1001, OrderDate = new DateOnly(2023, 1, 21) });
			Orders.Add(new OrderDetails() { OrderId = 5001, CustomerId = 101, ItemID = 1002, OrderDate = new DateOnly(2023, 1, 21) });
			Orders.Add(new OrderDetails() { OrderId = 5001, CustomerId = 101, ItemID = 1003, OrderDate = new DateOnly(2023, 1, 21) });
			Orders.Add(new OrderDetails() { OrderId = 5002, CustomerId = 101, ItemID = 1004, OrderDate = new DateOnly(2023, 1, 26) });
			Orders.Add(new OrderDetails() { OrderId = 5002, CustomerId = 101, ItemID = 1005, OrderDate = new DateOnly(2023, 1, 26) });

			Orders.Add(new OrderDetails() { OrderId = 5003, CustomerId = 102, ItemID = 1001, OrderDate = new DateOnly(2023, 2, 21) });
			Orders.Add(new OrderDetails() { OrderId = 5003, CustomerId = 102, ItemID = 1002, OrderDate = new DateOnly(2023, 2, 21) });
			Orders.Add(new OrderDetails() { OrderId = 5004, CustomerId = 102, ItemID = 1003, OrderDate = new DateOnly(2023, 1, 6) });
			Orders.Add(new OrderDetails() { OrderId = 5004, CustomerId = 102, ItemID = 1004, OrderDate = new DateOnly(2023, 1, 6) });
			Orders.Add(new OrderDetails() { OrderId = 5005, CustomerId = 102, ItemID = 1005, OrderDate = new DateOnly(2023, 6, 12) });

			Orders.Add(new OrderDetails() { OrderId = 5006, CustomerId = 103, ItemID = 1001, OrderDate = new DateOnly(2023, 4, 24) });
			Orders.Add(new OrderDetails() { OrderId = 5007, CustomerId = 103, ItemID = 1002, OrderDate = new DateOnly(2023, 7, 26) });
			Orders.Add(new OrderDetails() { OrderId = 5007, CustomerId = 103, ItemID = 1003, OrderDate = new DateOnly(2023, 7, 26) });
			Orders.Add(new OrderDetails() { OrderId = 5007, CustomerId = 103, ItemID = 1004, OrderDate = new DateOnly(2023, 7, 26) });
			Orders.Add(new OrderDetails() { OrderId = 5008, CustomerId = 103, ItemID = 1001, OrderDate = new DateOnly(2023, 1, 26) });
		}
	}

	public class CustomerDetails
	{
		public int CustomerID { get; set; }

		public string CustomerName { get; set; }
	}

	public class OrderDetails
	{
		public int OrderId { get; set; }

		public int CustomerId { get; set; }

		public int ItemID { get; set; }

		public DateOnly OrderDate { get; set; }
	}

	public class Item
	{
		public int ItemID { get; set; }

		public string ItemName { get; set; }

		public int Price { get; set; }
	}

	public class TestClass : IEquatable<TestClass?>
	{
		public TestClass(int custID, DateOnly ordDate)
		{
			this.custID = custID;
			this.ordDate = ordDate;
		}

		public int custID { get; set; }

		public DateOnly ordDate { get; set; }


		public bool Equals(TestClass? obj)
		{
			if (obj == null) return false;
			if (obj.custID == this.custID && obj.ordDate == this.ordDate)
			{
				return true;
			}
			return false;
		}
	}


}