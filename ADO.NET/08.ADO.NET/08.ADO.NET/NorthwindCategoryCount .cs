namespace NorthwindCategoryCount 
{
    using System;
    using System.Data.SqlClient;
    using System.Linq;

    public class NorthwindCategoryCount
    {
        /* Write a program that retrieves from the Northwind 
        sample database in MS SQL Server the number of rows in the Categories table. */

        public static void Main()
        {
            SqlConnection conn = new SqlConnection(
                 "Server= .\\SQLEXPRESS; " +
                 "Database=Northwind; " +
                 "Integrated Security=true");

            conn.Open();
            using (conn)
            {
                SqlCommand command = new SqlCommand("Select count(*) from Categories", conn);

                int numberOfCategories = (int)command.ExecuteScalar();
                Console.WriteLine(numberOfCategories);
            }
        }
    }
}
