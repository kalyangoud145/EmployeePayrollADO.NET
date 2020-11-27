using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayrollADO.NET
{
    /// <summary>
    /// POCO class for getting and setting the values
    /// </summary>
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public DateTime Start_Date { get; set; }
        public char Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public decimal basic_Pay { get; set; }
        public decimal Deductions { get; set; }
        public decimal Taxable_Pay { get; set; }
        public decimal Income_tax { get; set; }
        public decimal Net_Pay { get; set; }
        public int DepartmentNo { get;  set; }
        public int SalaryId { get; set; }

        /*public EmployeeModel(string name, decimal salary, DateTime start_Date, char gender, string phoneNumber, string address, string department, decimal basic_Pay, decimal deductions, decimal taxable_Pay, decimal income_tax, decimal net_Pay)
        {
            this.Name = name;
            this.Salary = salary;
            this.Start_Date = start_Date;
            this.Gender = gender;
            this.PhoneNumber = phoneNumber;
            this.Address = address;
            this.Department = department;
            this.basic_Pay = basic_Pay;
            this.Deductions = deductions;
            this.Taxable_Pay = taxable_Pay;
            this.Income_tax = income_tax;
            this.Net_Pay = net_Pay;
        }*/

    }
}
