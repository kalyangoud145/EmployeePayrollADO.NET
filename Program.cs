using System;
using System.Collections.Generic;

namespace EmployeePayrollADO.NET
{
    public class Program
    {
        static void Main(string[] args)
        {
            EmployeeRepo repo = new EmployeeRepo();
            EmployeeModel model = new EmployeeModel();
            model.basic_Pay = 30000;
            model.Deductions = 1500;
            model.Taxable_Pay = 15000;
            model.Income_tax = 4000;
            model.Net_Pay = 25000;
            model.Id = 3;
            model.DepartmentNo = 4;
            model.Department = "Marketing";
            model.Name = "Anirudh";
            model.Gender = 'M';
            model.Address = "HYD";
            repo.AddEmployeeDepartmentER(model);
            repo.GetAllDepartmentER();
            repo.GetAllPayrollER();
            repo.RetriveSum();
            repo.AverageOfBasicPay();
            repo.MaximumOfBasicPay();
        }
    }
}
