namespace FindProductsWhoMatchString
{
    using System;
    using System.Data.SqlClient;
    using System.Linq;

    public class ProgFindProductsWhoMatchString
    {
        //08. Write a program that reads a string from the console and finds all products that contain
        //this string. Ensure you handle correctly characters like ', %, ", \ and _.

        public static void Main(string[] args)
        {
            SqlConnection conn = new SqlConnection(
                "Server= .\\SQLEXPRESS; " +
                "Database=Northwind; " +
                "Integrated Security=true");

            conn.Open();

            using(conn)
            {
                Console.Write("Input string to search: ");
                string searchString = Console.ReadLine();

                searchString = searchString.Replace("%", " ").Replace("\\", " ").Replace("_", " ").Replace("'", " ").Replace("\"", " ").Trim();
                string sqlComm = string.Format("Select ProductName from Products where ProductName like '%" + searchString + "%'");

                SqlCommand command = new SqlCommand(sqlComm, conn);
                SqlDataReader reader = command.ExecuteReader();

                Console.WriteLine("RESULTS");
                while (reader.Read())
                {
                    Console.WriteLine((string)reader["ProductName"]);

                }
            }
        }
    }
}
