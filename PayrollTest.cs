using EmployeePayrollADO.NET;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeePayrollTest
{
    [TestClass]
    public class PayrollTest
    {
        /// <summary>
        /// Givens the payroll data to update when datais present in 
        /// table should return true if data is updated.
        /// </summary>
        [TestMethod]
        public void GivenPayrollToUpdate_WhenDataisPresentInTable_ShouldReturnTrueIfDataIsUpdated()
        {
            // Act
            EmployeeRepo repo = new EmployeeRepo();
            bool Emp_BasicPay = repo.UpdateTables("update Employee_Payroll set basic_Pay = 3000000.00 where Id=5");
            // Assert
            Assert.AreEqual(Emp_BasicPay, true);
        }
    }
}