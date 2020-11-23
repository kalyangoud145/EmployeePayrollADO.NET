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
    }
}
