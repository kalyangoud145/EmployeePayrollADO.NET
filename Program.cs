using System;
using System.Collections.Generic;

namespace EmployeePayrollADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeRepo repo = new EmployeeRepo();
            repo.GetEmployeesJoiningAfterADate("SELECT * FROM Employee_Payroll where Start_Date between CAST('2018-01-01' AS DATE) AND CAST('2020-11-05' AS DATE)");       
        }
    }
}
