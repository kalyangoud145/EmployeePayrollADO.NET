using EmployeePayrollADO.NET;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeePayrollTest
{
    [TestClass]
    public class PayrollTest
    {
            [TestMethod]
            public void GivenPayrollToUpdate_WhenDataisPresentInTable_ShouldReturnTrueIfDataIsUpdated()
            {
                EmployeeRepo repo = new EmployeeRepo();
                bool Emp_BasicPay = repo.UpdateTables("update Employee_Payroll set basic_Pay = 3000000.00 where Id=5");

                Assert.AreEqual(Emp_BasicPay, true);
            }
    }
}
