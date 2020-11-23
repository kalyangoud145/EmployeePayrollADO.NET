using System;

namespace EmployeePayrollADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeModel employeeModel = new EmployeeModel();
            EmployeeRepo repo = new EmployeeRepo();
            employeeModel.Name = "Keerthi";
            employeeModel.Salary = 50000;
            employeeModel.Gender = 'F';
            employeeModel.PhoneNumber = "864023030";
            employeeModel.Address = "HYD";
            employeeModel.Department = "CiVils";
            employeeModel.basic_Pay = 30000;
            employeeModel.Deductions = 12000;
            employeeModel.Taxable_Pay = 40000;
            employeeModel.Income_tax = 7000;
            employeeModel.Net_Pay = 41000;
            repo.AddEmployee(employeeModel);
        }
    }
}
