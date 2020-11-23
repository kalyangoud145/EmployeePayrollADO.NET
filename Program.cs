using System;

namespace EmployeePayrollADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeModel employeeModel = new EmployeeModel();
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
