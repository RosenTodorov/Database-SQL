namespace CategoryNameAndContainingProducts
{
    using System;
    using System.Linq;
    using System.Data.SqlClient;
    using System.Text;

    public class CategoryNameAndContainingProducts
    {
        //03. Write a program that retrieves from the Northwind database all product categories
        //and the names of the products in each category. Can you do this with a single SQL query (with table join)?

        public static void Main()
        {
            SqlConnection conn = new SqlConnection(
                "Server= .\\SQLEXPRESS; " +
                "Database=Northwind; " +
                "Integrated Security=true");

            conn.Open();
            using (conn)
            {
                SqlCommand command = new SqlCommand(@"SELECT p.ProductName, c.CategoryName
                                                            FROM Products p
                                                            JOIN Categories c
                                                            ON p.CategoryID = c.CategoryID", conn);

                SqlDataReader reader = command.ExecuteReader();
                var result = new StringBuilder();

                using (reader)
                {
                    while (reader.Read())
                    {
                        result.AppendLine(string.Format((string)reader["ProductName"] + "  --->  " + (string)reader["CategoryName"]));
                    }
                }
                Console.WriteLine(result);
            }
            /*
            using (dbCon)
            {
                SqlCommand cmdGetCategoriesAndProductsInThem = new SqlCommand(
                    "SELECT c.CategoryName, p.ProductName FROM Categories c " +
                    "JOIN Products p " +
                    "ON c.CategoryID = p.CategoryID " +
                    "GROUP BY c.CategoryName, p.ProductName", dbCon);

                SqlDataReader reader = cmdGetCategoriesAndProductsInThem.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine
                            ("Category: {0}; Product: {1}",
                            (string)reader["CategoryName"],
                            (string)reader["ProductName"]);
                    }
                }
            } */
        }
    }
}
