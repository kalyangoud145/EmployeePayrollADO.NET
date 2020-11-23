using System;
using System.Collections.Generic;

namespace EmployeePayrollADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeRepo repo = new EmployeeRepo();
            repo.DeleteValue();
        }
    }
}
