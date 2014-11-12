namespace AddProductParameterized
{
    using System;
    using System.Data.SqlClient;

    public class AddProductParameterized
    {
        //04. Write a method that adds a new product in the products table in the Northwind database.
        //Use a parameterized SQL command.

        public static void Main()
        {
            SqlConnection conn = new SqlConnection(
                "Server= .\\SQLEXPRESS; " +
                "Database=Northwind; " +
                "Integrated Security=true");

            conn.Open();
            using (conn)
            {
                SqlCommand command = new SqlCommand(@"INSERT INTO Products (ProductName, SupplierID, CategoryID) " +
                                                       "VALUES (@name, @supplierid, @categoryid)", conn);
                command.Parameters.AddWithValue("@name", "Power Nutrition");
                command.Parameters.AddWithValue("@supplierid", 1);
                command.Parameters.AddWithValue("@categoryid", 7);
                command.ExecuteNonQuery();
            }
            Console.WriteLine("ready");
        }
    }
}
    

