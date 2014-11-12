namespace NPlusOneProblem
{
    using System;
    using TelerikAcademy.Model;

    public class NPlusOneProblem
    {
        /* 01. Using Entity Framework write a SQL query to select all employees from the Telerik Academy database and later print their name, department and town. 
         * Try the both variants: with and without .Include(…). Compare the number of executed SQL statements and the performance.*/

        public static void Main()
        {
            PrintEmployeesWithoutInclude(); 
            PrintEmployeesOptimized();
        }

        private static void PrintEmployeesWithoutInclude()
        {
            using (var telerikAcademyDBContext = new TelerikAcademyEntities())
            {
                var employees = telerikAcademyDBContext.Employees;
                foreach (var employee in employees)
                {
                    Console.WriteLine("Name: {0}, Department: {1}, Town: {2}", employee.FirstName + ' ' + employee.LastName, employee.Department.Name, employee.Address.Town.Name);
                }
            }
        }

        private static void PrintEmployeesOptimized()
        {
            using (var telerikAcademyDBContext = new TelerikAcademyEntities())
            {
                var employees = telerikAcademyDBContext.Employees.Include("Departments").Include("Address.Town");
                foreach (var employee in employees)
                {
                    Console.WriteLine("Name: {0}, Department: {1}, Town: {2}", employee.FirstName + ' ' + employee.LastName, employee.Department.Name, employee.Address.Town.Name);
                }
            }
        }
    }
}
