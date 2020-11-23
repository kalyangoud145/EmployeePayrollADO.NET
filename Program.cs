using System;

namespace EmployeePayrollADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeRepo repo = new EmployeeRepo();
            Console.WriteLine(repo.UpdateTables("update Employee_Payroll set basic_Pay = 3000000.00 where Id=5") ); 
        }
    }
}
