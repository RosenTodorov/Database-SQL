namespace _01.NorthwindDbContex
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using _01.NorthwindDbContex;

    public static class DAO
    {
        public static void FindSalesByRegionAndPeriod(string region, string startDate = null, string endDate = null)
        {
            NorthwindEntities northwindDbContex = new NorthwindEntities();

            using (northwindDbContex)
            {
                DateTime startDateDt = Convert.ToDateTime(startDate);
                DateTime endDateDt = Convert.ToDateTime(endDate);

                var salesByRegionAndPeriod = northwindDbContex
                                            .Orders
                                            .Where(o => o.ShipRegion == region &&
                                                    o.OrderDate >= startDateDt && o.OrderDate <= endDateDt)
                                            .GroupBy(o => o.ShipName);

                foreach (var item in salesByRegionAndPeriod)
                {
                    Console.WriteLine(item.Key);
                }

            }
        }

        public static void InsertCustomer(string customerId, string companyName, string contactName = null,
            string contactTitle = null, string address = null, string city = null, string region = null,
            string postalCode = null, string country = null, string phone = null, string fax = null)
        {
            NorthwindEntities northwindDbContex = new NorthwindEntities();

            using (northwindDbContex)
            {
                Customer newCustomer = new Customer
                {
                    CustomerID = customerId,
                    CompanyName = companyName,
                    ContactName = contactName,
                    ContactTitle = contactTitle,
                    Address = address,
                    City = city,
                    Region = region,
                    PostalCode = postalCode,
                    Country = country,
                    Phone = phone,
                    Fax = fax
                };

                northwindDbContex.Customers.Add(newCustomer);
                northwindDbContex.SaveChanges();
                Console.WriteLine("1 row affected.");
            }

        }

        public static void UpdateCustomer(string customerId, string companyName, string contactName = null,
            string contactTitle = null, string address = null, string city = null, string region = null,
            string postalCode = null, string country = null, string phone = null, string fax = null)
        {
            NorthwindEntities northwindDbContex = new NorthwindEntities();

            using (northwindDbContex)
            {
                Customer customer = northwindDbContex.Customers.First(c => c.CustomerID == customerId);

                customer.CompanyName = companyName ?? customer.CompanyName;
                customer.ContactName = contactName ?? customer.ContactName;
                customer.ContactTitle = contactTitle ?? customer.ContactTitle;
                customer.Address = address ?? customer.Address;
                customer.City = city ?? customer.City;
                customer.Region = region ?? customer.Region;
                customer.PostalCode = postalCode ?? customer.PostalCode;
                customer.Country = country ?? customer.Country;
                customer.Phone = phone ?? customer.Phone;
                customer.Fax = fax ?? customer.Fax;

                northwindDbContex.SaveChanges();
                Console.WriteLine("! row affected.");
            }
        }

        public static void DeleteCustomer(string customerId)
        {
            NorthwindEntities northwindDbContex = new NorthwindEntities();

            using (northwindDbContex)
            {
                Customer customer = northwindDbContex.Customers.First(c => c.CustomerID == customerId);

                northwindDbContex.Customers.Remove(customer);
                northwindDbContex.SaveChanges();

                Console.WriteLine("1 row removed.");
            }
        }

        public static void FindCustomersWithOrdersFrom1997ToCanade()
        {
            NorthwindEntities northwindDbContex = new NorthwindEntities();

            using (northwindDbContex)
            {
                var customers = northwindDbContex.Orders
                                                    .Where(o => o.OrderDate.Value.Year == 1997 &&
                                                        o.ShipCountry == "Canada")
                                                    .GroupBy(o => o.Customer.CompanyName)
                                                    .ToList();

                northwindDbContex.SaveChanges();

                foreach (var customer in customers)
                {
                    Console.WriteLine(customer.Key);
                }
            }
        }

        public static void FindCustomersWithOrdersFrom1997ToCanadeNativeSQL()
        {
            NorthwindEntities northwindDbContex = new NorthwindEntities();

            string querySql = "SELECT c.CompanyName FROM Orders o " +
                              "JOIN Customers c ON c.CustomerID  = o.CustomerID " +
                              "WHERE YEAR(o.OrderDate) = 1997 And o.ShipCountry = 'Canada' " +
                              "GROUP BY c.CompanyName";

            var customers = northwindDbContex.Database.SqlQuery<string>(querySql);

            foreach (var customer in customers)
            {
                Console.WriteLine(customer);
            }
        }
    }
}
/*  public static void InsertCustomer(string customerID, string companyName, string contactName, string contactTitle, string address, string city,
              string region, string postalCode, string country, string phone, string fax)
          {
              using (var baseConn = new NorthwindEntities())
              {
                  bool success = false;
                  try
                  {
                      Customer newCustomer = new Customer
                      {
                          CustomerID = customerID,
                          CompanyName = companyName,
                          ContactName = contactName,
                          ContactTitle = contactTitle,
                          Address = address,
                          City = city,
                          Region = region,
                          PostalCode = postalCode,
                          Country = country,
                          Phone = phone,
                          Fax = fax
                      };

                      if (baseConn.Customers.Find(newCustomer.CustomerID) == null && newCustomer.CustomerID != null)
                      {
                          baseConn.Customers.Add(newCustomer);
                          baseConn.SaveChanges();
                          success = true;
                      }
                  }
                  finally
                  {
                      if (success)
                      {
                          Console.WriteLine("Customer added");
                      }
                      else
                      {
                          Console.WriteLine("Custumer not added");
                      }
                  }
              }
          }
          public static void DeleteCustomer(string customerID)
          {
              using (var baseConn = new NorthwindEntities())
              {
                  bool success = false;

                  try
                  {
                      var customerToRemove = baseConn.Customers.Find(customerID);
                      baseConn.Customers.Remove(customerToRemove);
                      baseConn.SaveChanges();
                      success = true;
                  }
                  finally
                  {
                      if (success)
                      {
                          Console.WriteLine("Custumer deleted");
                      }
                      else
                      {
                          Console.WriteLine("Custumer could not be deleted");
                      }
                  }
              }
          }
          public static void ModifyCustomer(string customerID, string companyName)
          {
              using (var baseConn = new NorthwindEntities())
              {
                  var customerToModify = baseConn.Customers.Find(customerID);
                  customerToModify.CompanyName = companyName;
                  baseConn.SaveChanges();
              }
          }

          public static Customer GetCustomerByCriterion(string criterion, string searchValue)
          {
              Customer result = null;

              using (var baseConn = new NorthwindEntities())
              {
                  foreach (var item in baseConn.Customers)
                  {
                      var itemProp = item.GetType().GetProperty(criterion);
                      if (itemProp.GetValue(item, null).ToString() == searchValue)
                      {
                          result = item;
                          break;
                      }

                  }
              }

              return result;
          }

          //03. Write a method that finds all customers who have orders made in 1997 and shipped to Canada.
          public static void PrintOrders()
          {
              using (var baseConn = new NorthwindEntities())
              {
                  var customers = baseConn.Customers.Where(x => x.Orders.Where(o => o.OrderDate.Value.Year == 1997 && o.ShipCountry == "Canada").Any());

                  foreach (var item in customers)
                  {
                      Console.WriteLine(item.CustomerID);
                  }
              }
          }

          //04. Implement previous by using native SQL query and executing it through the ObjectContext.
          public static void PrintOrderWithSQL()
          {
              using (var baseConn = new NorthwindEntities())
              {
                  var customers = baseConn.Database.SqlQuery<string>(@"SELECT distinct c.CustomerID
                                                                       FROM Customers c JOIN Orders o
                                                                       ON c.CustomerID = o.CustomerID                
                                                                       WHERE o.ShipCountry ='Canada' AND o.OrderDate like '%1997'");
                  foreach (var item in customers)
                  {
                      Console.WriteLine(item);
                  }
              }
          }

          //05.Write a method that finds all the sales by specified region and period (start / end dates).
          public static void PrintSalesByRegionAndPeriod()
          {
              var query = SelectOrdersByRegionAndDate("NM", new DateTime(1996, 01, 01), new DateTime(1997, 01, 01));
              foreach (var res in query)
              {
                  Console.WriteLine(res);
              }
          }
          private static ICollection<string> SelectOrdersByRegionAndDate(string region, DateTime start, DateTime end)
          {
              using (var baseConn = new NorthwindEntities())
              {
                  var result = baseConn.Orders.Where(
                      x => x.ShipRegion == region && x.OrderDate >= start && x.OrderDate <= end).Select(
                      c => c.Customer.CompanyName + " " + c.ShipAddress + " " + c.ShipCountry).ToList();

                  return result;
              }
          }
      }
  } */
