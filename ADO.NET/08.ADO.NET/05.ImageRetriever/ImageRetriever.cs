namespace ImageRetriever
{
    using System;
    using System.Data.SqlClient;
    using System.IO;
    using System.Linq;

    public class ImageRetriever
    {
        //05. Write a program that retrieves the images for all categories in the Northwind database
        //and stores them as JPG files in the file system.

        public static void Main()
        {
            byte[] imageFromDB;
            string categoryName;

            SqlConnection conn = new SqlConnection(
                "Server= .\\SQLEXPRESS; " +
                "Database=Northwind; " +
                "Integrated Security=true");

            conn.Open();
            using(conn)
            {
                SqlCommand command = new SqlCommand(
                    "SELECT CategoryName, Picture " + "FROM Categories", conn);
                SqlDataReader reader = command.ExecuteReader();

                using(reader)
                {
                    while (reader.Read())
                    {
                        imageFromDB = (byte[])reader["Picture"];
                        categoryName = (string)reader["CategoryName"];
                        categoryName = categoryName.Replace("/", string.Empty);
                        WriteBinaryFile(@"..\..\" + categoryName + ".JPG", imageFromDB);
                    }
                }           
            }
        }

        private static void WriteBinaryFile(string fileName, byte[] fileContents)
        {
            FileStream stream = File.OpenWrite(fileName);
            using(stream)
            {
                stream.Write(fileContents, 78, fileContents.Length - 78);
            }      
        }
    }
}
