namespace GetsNameAndDescriptionOfCategories
{
    using System;
    using System.Data.SqlClient;
    using System.Text;

    public class GetsNameAndDescriptionOfCategories
    {
        //Write a program that retrieves the name and description of all categories in the Northwind DB

        public static void Main()
        {
            SqlConnection conn = new SqlConnection(
                "Server= .\\SQLEXPRESS; " +
                "Database=Northwind; " +
                "Integrated Security=true");

            conn.Open();
            using (conn)
            {
                SqlCommand retrieveNameDescription = new SqlCommand("Select CategoryName, Description from Categories", conn);
                
                SqlDataReader reader = retrieveNameDescription.ExecuteReader();
                var result = new StringBuilder();

                using (reader)
                {
                    while (reader.Read())
                    {
                        result.AppendLine(string.Format((string)reader["CategoryName"] + " --> " + (string)reader["Description"]));
                    }
                }
                Console.WriteLine(result);
                /*
                     using (reader)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine
                            ("Name: {0}; Descrpiption: {1}",
                            (string) reader["CategoryName"],
                            (string) reader["Description"]);
                    }
                }
                 */
            }    
        }
    }
}
