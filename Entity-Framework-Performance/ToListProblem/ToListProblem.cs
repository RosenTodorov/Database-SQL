namespace ToListProblem
{
    using System;
    using System.Linq;
    using TelerikAcademy.Model;

    public class ToListProblem
    {
        /* 02. Using Entity Framework write a query that selects all employees from the Telerik Academy database, 
         * then invokes ToList(), then selects their addresses, then invokes ToList(), then selects their towns, 
         * then invokes ToList() and finally checks whether the town is "Sofia". 
         * Rewrite the same in more optimized way and compare the performance.*/

        public static void Main()
        {
            SelectWithMultipleToList(); 
            SelectWithOptimizedToList(); 
        }

        private static void SelectWithMultipleToList()
        {
            using (var telerikAcademyDBContext = new TelerikAcademyEntities())
            {
                var result = telerikAcademyDBContext.Employees.ToList().Select(e => e.Address).ToList().Select(a => a.Town).ToList().Where(t => t.Name == "Sofia").ToList();
            }
            Console.WriteLine("Done!");
        }

        private static void SelectWithOptimizedToList()
        {
            using (var telerikAcademyDBContext = new TelerikAcademyEntities())
            {
                var result = telerikAcademyDBContext.Employees.Select(e => e.Address).Select(a => a.Town).Where(t => t.Name == "Sofia").ToList();
            }
            Console.WriteLine("Done!");
        }
    }
}
