//07. Implement appending new rows to the Excel file.

namespace AddRowsToExcelFile
{
    using System;
    using System.Data.OleDb;
    using System.Linq;

    public class AddRowsToExcelFile
    {
        public static void Main()
        {
            OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=""../../sampleFile.xls"";Extended Properties=Excel 8.0;");
            OleDbCommand command = new OleDbCommand("Insert INTO [Sheet1$] Values(@name, @score)", connection);
            connection.Open();

            using(connection)
            {
                Console.Write("Enter name to insert: ");
                string name = Console.ReadLine();
                Console.Write("Enter score to insert: ");
                double? score = double.Parse(Console.ReadLine());
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@score", score);
                command.ExecuteScalar();
                Console.WriteLine("Record Added");
            }
        }
    }
}