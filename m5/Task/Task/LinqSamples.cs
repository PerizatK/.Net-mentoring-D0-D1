// Copyright © Microsoft Corporation.  All Rights Reserved.
// This code released under the terms of the 
// Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)
//
//Copyright (C) Microsoft Corporation.  All rights reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Odbc;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using SampleSupport;
using Task.Data;

// Version Mad01

namespace SampleQueries
{
	[Title("LINQ Module")]
	[Prefix("Linq")]
	public class LinqSamples : SampleHarness
	{

		private DataSource dataSource = new DataSource();

		[Category("Restriction Operators")]
		[Title("Where - Task 1")]
		[Description("This sample uses the where clause to find all elements of an array with a value less than 5.")]
		public void Linq1()
		{
			int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

			var lowNums =
				from num in numbers
				where num < 5
				select num;

			Console.WriteLine("Numbers < 5:");
			foreach (var x in lowNums)
			{
				Console.WriteLine(x);
			}
		}

		[Category("Restriction Operators")]
		[Title("Where - Task 2")]
		[Description("This sample return return all presented in market products")]

		public void Linq2()
		{
			var products =
				from p in dataSource.Products
				where p.UnitsInStock > 0
				select p;

			foreach (var p in products)
			{
				ObjectDumper.Write(p);
			}
		}

		[Category("Where&Sum Operators")]
		[Title("Task 1")]
		[Description("This sample returns list of customers whom sum of all their orders more then x")]
		public void Linq001()
		{
			decimal x = 5000;

			var customersList = dataSource.Customers
				.Where(c => c.Orders.Sum(o => o.Total) > x)
				.Select(c => new
				{
					Name = c.CompanyName,
					TotalSum = c.Orders.Sum(o => o.Total)
				});

			foreach (var c in customersList)
			{
				ObjectDumper.Write(c);
			}

		}

		[Category("Join operator")]
		[Title("Task 2_1")]
		[Description("List of clients and suppliers that located in same country&city without grouping")]
		public void Linq002_1()
		{
			var customerSupplierList = dataSource.Customers
				.Join(dataSource.Suppliers,
				c => new { c.City, c.Country },
				s => new { s.City, s.Country },
				(c, s) => new { c.CustomerID, c.CompanyName, s.SupplierName });

			//from c in dataSource.Customers
			//					   join s in dataSource.Suppliers
			//					   on new { c.City, c.Country } equals new { s.City, s.Country }
			//					   select new { c.CustomerID, c.CompanyName, s.SupplierName};

			foreach (var c in customerSupplierList)
			{
				ObjectDumper.Write(c);
			}
		}

		[Category("GroupJoin")]
		[Title("Task 2_2")]
		[Description("List of clients ans suppliers that located in same country&city with grouping")]
		public void Linq002_2()
		{
			var customerSupplierList = dataSource.Customers.GroupJoin(
				dataSource.Suppliers,
				c => new { c.City, c.Country },
				s => new { s.City, s.Country },
				(customer, supplier) => new
				{
					CustomerId = customer.CustomerID,
					CustomerCompanyName = customer.CompanyName,
					SupplierName = supplier.Select(sp => sp.SupplierName)
				}
				)
				.ToList();
			foreach (var cs in customerSupplierList)
			{
				foreach (string s in cs.SupplierName)
				{
					ObjectDumper.Write($"CustomerId = {cs.CustomerId}, CustomerCompanyName = {cs.CustomerCompanyName}, SupplierName = {s}");
				}
			}
		}

		[Category("More than x")]
		[Title("Task 3")]
		[Description("List of clients which has an orders with total more than X")]
		public void Linq003()
		{
			decimal x = 5000;

			var customersList = from c in dataSource.Customers
								from o in c.Orders
								orderby c.CustomerID, o.Total
								where o.Total > x
								select new { c.CustomerID, c.CompanyName, o.Total };

			foreach (var c in customersList)
			{
				ObjectDumper.Write(c);
			}
		}

		[Category("Min(datetime)")]
		[Title("Task 4")]
		[Description("List of customers with year and month when their first order was created")]
		public void Linq004()
		{
			var customersList = from c in dataSource.Customers
								from o in c.Orders
								orderby c.CustomerID
								where o.OrderDate == c.Orders.Min(o => o.OrderDate)
								select new { c.CustomerID, c.CompanyName, o.OrderDate.Year, o.OrderDate.Month };


			foreach (var c in customersList)
			{
				ObjectDumper.Write(c);
			}
		}

		[Category("Min(datetime) (ordered)")]
		[Title("Task 5")]
		[Description("List of customers with year and month when their first order was created (ordered by year of order, month of order, order total (from max to min) and companyName")]
		public void Linq005()
		{
			var customersList = from c in dataSource.Customers
								from o in c.Orders
								orderby o.OrderDate.Year, o.OrderDate.Month, o.Total descending, c.CompanyName
								where o.OrderDate == c.Orders.Min(o => o.OrderDate)
								select new { c.CustomerID, c.CompanyName, o.OrderDate.Year, o.OrderDate.Month, o.Total };


			foreach (var c in customersList)
			{
				ObjectDumper.Write(c);
			}
		}

		[Category("Any&&isNullOrEmpty&&FirstOrDefault")]
		[Title("Task 6")]
		[Description("customer has non numeric postcode or region is empty or null or phone number doesn't start with '(' ")]
		public void Linq006()
		{
			var customersList = dataSource.Customers
								.Where(c=> (c.PostalCode != null && c.PostalCode.Any(num => num < '0' || num > '9'))
                                || string.IsNullOrEmpty(c.Region)
                                || c.Phone.StartsWith("(")
								)
								.Select(c=> new { c.CustomerID, c.PostalCode, c.Region, c.Phone});

			foreach (var c in customersList)
			{
				ObjectDumper.Write(c);
			}
		}

		[Category("Group by category")]
		[Title("Task 7")]
		[Description("Group products by category then by existence in stock then by unitprice")]
		public void Linq007()
		{
			var customersList = dataSource.Products
				.GroupBy(p => p.Category)
				.Select(pr => new
				{
					CategoryName = pr.Key,
					exists = pr.GroupBy(pro => pro.UnitsInStock > 0)
					.Select(prod => new
					{
						AmountLeft = prod.Key,
						prices = prod.GroupBy(produ => produ.UnitPrice)
						.Select(produc => new
						{
							Price = produc.Key
						})
					})
				});
			
			foreach (var c in customersList)
			{
				ObjectDumper.Write(c,2);
			}
		}

		[Category("Group by price")]
		[Title("Task 8")]
		[Description("Group products by unit price: cheap (x<100), average (100<x<200), expensive (x>200)")]
		public void Linq008()
		{
			var customersList = from p in dataSource.Products
								orderby p.UnitPrice
								group p by (p.UnitPrice < 100 ? "Cheap" : p.UnitPrice > 200 ? "Expensive" : "Average") into pr
								select new { priceType = pr.Key, Product = pr };

			foreach (var c in customersList)
			{
				ObjectDumper.Write(c,2);
			}
		}


		[Category("Average")]
		[Title("Task 9")]
		[Description("Average orders total, average amount of orders")]
		public void Linq009()
		{
            var customersList = dataSource.Customers
				.OrderBy(c=>c.City)
                .GroupBy(c => c.City)
				.Select (c=> new
				{
					city = c.Key,
					AverageTotalOfOrder = c.Average(cu=>cu.Orders.Count()),
					AverageAmountOfOrder = c.Average(cu=>cu.Orders.Sum(o=>o.Total))
				});

			foreach (var c in customersList)
			{
				ObjectDumper.Write(c);
			}

		}

		[Category("Count, GroupBy")]
		[Title("Task 010")]
		[Description("Average statistic by month, year, yearMonth")]

		public void Linq003_____Check()
		{
			var customersList = dataSource.Customers
				.Select(c => new
				{
					c.CompanyName,

					Month = c.Orders
					.GroupBy(o=>o.OrderDate.Month)
					.Select(cgroup => new 
					{
						Month = cgroup.Key, 
						OrdersinMonth = cgroup.Count()
					}),

					Year = c.Orders
					.GroupBy(o => o.OrderDate.Year)
					.Select(cgroup => new
					{
						Year = cgroup.Key,
						OrdersinYear = cgroup.Count()
					}),

					YearMonth = c.Orders
					.GroupBy(o => new { o.OrderDate.Year, o.OrderDate.Month })
					.Select(cgroup => new
					{
						Year = cgroup.Key.Year,
						Month = cgroup.Key.Month,
						OrdersinYearMonth = cgroup.Count()
					}),
				});


			foreach (var c in customersList)
			{
				ObjectDumper.Write(c,3);
			}
		}
	}
}
