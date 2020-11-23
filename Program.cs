using System;
using System.Collections.Generic;

namespace EmployeePayrollADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeRepo repo = new EmployeeRepo();
            repo.SumOfSalaryGenderWise();
            Console.WriteLine("******");
            repo.AverageOfSalaryGenderWise();
            Console.WriteLine("******");
            repo.MinimumSalaryGenderWise();
            Console.WriteLine("******");
            repo.MaximumSalaryGenderWise();
            Console.WriteLine("******");
            repo.CountOfEmployeesGenderWise();
        }
    }
}
