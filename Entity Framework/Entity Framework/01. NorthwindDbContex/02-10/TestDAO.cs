using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.NorthwindDbContex
{
    using System;

    public class TestDAO
    {
     public static void Main()
        {
            //02. Create a DAO class with static methods which provide functionality for inserting, modifying and deleting customers. Write a testing class.

            DAO.InsertCustomer("PESHO", "Telerik Academy");
            DAO.UpdateCustomer("PESHO", "NESTLE");
            DAO.DeleteCustomer("PESHO");

            //03. Write a method that finds all customers who have orders made in 1997 and shipped to Canada.

            DAO.FindCustomersWithOrdersFrom1997ToCanade();

            //04. Implement previous by using native SQL query and executing it through the DbContext.

            DAO.FindCustomersWithOrdersFrom1997ToCanadeNativeSQL();

            //05. Write a method that finds all the sales by specified region and period (start / end dates).

            DAO.FindSalesByRegionAndPeriod("RJ", "1995-01-01", "1999-09-12");

            //06. Create a database called NorthwindTwin with the same structure as Northwind using the features from DbContext. Find for the API for schema generation in MSDN or in Google.

            //Just changing the database name in the app.congig file makes EF to create it if it does not exist by the model.
            NorthwindEntities northwindTwinDbContex = new NorthwindEntities();
            northwindTwinDbContex.Database.CreateIfNotExists();

            //07. Try to open two different data contexts and perform concurrent changes on the same records. What will happen at SaveChanges()? How to deal with it?
         /*
            NorthwindEntities secondNorthwindTwinDbContex = new NorthwindEntities();

            using (northwindTwinDbContex)
            {
                using (secondNorthwindTwinDbContex)
                {
                    DAO.InsertCustomer("MMM", "Microsoft");
                    DAO.UpdateCustomer("MMM", "Telerik");
            
                    Customer customer = northwindTwinDbContex.Customers.Find("MMM");
                    customer.ContactName = "Gosho";
            
                    Customer sameCustomer = secondNorthwindTwinDbContex.Customers.Find("MMM");
                    sameCustomer.ContactName = "Misho";
            
                    northwindTwinDbContex.SaveChanges();
                    secondNorthwindTwinDbContex.SaveChanges();
                }
            } */
          
            //08. By inheriting the Employee entity class create a class which allows employees to access their corresponding territories as property of type EntitySet<T>.

            NorthwindEntities northwindDbContex = new NorthwindEntities();

            using (northwindDbContex)
            {
                Employee employee = northwindDbContex.Employees.First(); 

                foreach (var territory in employee.Territories)
                {
                    Console.WriteLine(territory.TerritoryDescription);
                }
            }

            //09. Create a method that places a new order in the Northwind database. The order should contain several order items. Use transaction to ensure the data consistency.

            northwindDbContex = new NorthwindEntities();

            using (northwindDbContex)
            {
                using (var dbContextTransaction = northwindDbContex.Database.BeginTransaction())
                {
                    try
                    {
                        northwindDbContex.Orders.Add(
                                    new Order
                                    {
                                        CustomerID = "ROMEY",
                                        EmployeeID = 4
                                    });
                        northwindDbContex.SaveChanges();

                        Order order = northwindDbContex
                                        .Orders
                                        .Where(o => o.CustomerID == "ROMEY" && o.EmployeeID == 4)
                                        .FirstOrDefault();

                        Console.WriteLine(order.CustomerID);
                        dbContextTransaction.Commit();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        dbContextTransaction.Rollback();
                    }
                }
            }

          //10. Create a stored procedures in the Northwind database for finding the total incomes for given supplier name and period (start date, end date). Implement a C# method that calls the stored procedure and returns the retuned record set.

            northwindDbContex = new NorthwindEntities();

            using (northwindDbContex)
            {
                northwindDbContex.Database.ExecuteSqlCommand("CREATE PROCEDURE usp_GetIncomeByGivenCompany " +
                "@companyName nvarchar(60), @startDate date, @endDate date AS " +
                "SELECT s.CompanyName, SUM(od.UnitPrice * od.Quantity) AS Income " +
                "FROM Suppliers s " +
                "JOIN Products p " +
                "ON s.SupplierID = p.SupplierID " +
                "JOIN [Order Details] od " +
                "ON p.ProductID = od.ProductID " +
                "JOIN Orders o " +
                "ON od.OrderID = o.OrderID " +
                "where o.ShippedDate > @startDate AND o.ShippedDate < @endDate " +
                "AND s.CompanyName = @companyName " +
                "GROUP BY s.CompanyName");

                string companyName = "Exotic Liquids";
                DateTime startDate = new DateTime(1990, 1, 1);
                DateTime endDate = new DateTime(1999, 1, 1);

                var col = northwindDbContex.usp_GetIncomeByGivenCompany(companyName, startDate, endDate).First();
                Console.WriteLine("Company name: {0} -> Income: {1}", col.CompanyName, col.Income);
            }
        }
    }
}
     