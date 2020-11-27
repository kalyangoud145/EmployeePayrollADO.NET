using EmployeePayrollADO.NET;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace EmployeePayrollTest
{
    [TestClass]
    public class PayrollTest
    {
        /* /// <summary>
         /// Givens the payroll data to update when datais present in 
         /// table should return true if data is updated.
         /// </summary>
         [TestMethod]
         public void GivenPayrollToUpdate_WhenDataisPresentInTable_ShouldReturnTrueIfDataIsUpdated()
         {
             // Act
             EmployeeRepo repo = new EmployeeRepo();
             bool actual = repo.UpdateTables("update Employee_Payroll set basic_Pay = 3000000.00 where Id=5");
             // Assert
             Assert.IsTrue(actual);
         }
         /// <summary>
         /// Givens the payroll data to update when datais not in the
         /// table should return false if data is updated.
         /// </summary>
         [TestMethod]
         public void GivenPayrollToUpdate_WhenDataisPresentInTable_ShouldReturnFalseIfDataIsUpdated()
         {
             // Act
             EmployeeRepo repo = new EmployeeRepo();
             bool actual = repo.UpdateTables("update Employee_Payroll set basic_Pay = 3000000.00 where Id= 10");
             // Assert
             Assert.IsFalse(actual);
         }
         /// <summary>
         /// Given correct Data To Add To Employee Table When Database Is Connected Should Return True
         /// </summary>
         [TestMethod]
         public void GivencorrectDataToAddToEmployeeTable_WhenDatabaseIsConnected_ShouldReturnTrue()
         {
             // Act
             EmployeeRepo repo = new EmployeeRepo();
             EmployeeModel model = new EmployeeModel();
             model.Name = "Bhanu";
             model.Gender = 'M';
             model.Address = "HYD";
             model.PhoneNumber = "9550647660";
             model.DepartmentNo = 4;
             bool actual = repo.AddEmployeeER(model);
             Assert.IsTrue(actual);
         }
         /// <summary>
         /// Given Incorrect Data To Add To Employee Table When Database Is Connected Should Return false
         /// </summary>
         [TestMethod]
         public void GivenIncorrectDataToAddToEmployeeTable_WhenDatabaseIsConnected_ShouldReturnFalse()
         {
             // Act
             EmployeeRepo repo = new EmployeeRepo();
             EmployeeModel model = new EmployeeModel();
             model.Name = "Bhanu";
             model.Gender = 'M';
             model.Address = "HYD";
             bool actual = repo.AddEmployeeER(model);
             Assert.IsFalse(actual);
         }
         /// <summary>
         /// Given correct Data To Add To Department Table When Database Is Connected Should Return True
         /// </summary>
         [TestMethod]
         public void GivencorrectDataToAddToDepartmentTable_WhenDatabaseIsConnected_ShouldReturnTrue()
         {
             // Act
             EmployeeRepo repo = new EmployeeRepo();
             EmployeeModel model = new EmployeeModel();
             model.Department = "delivery";
             model.DepartmentNo = 5;
             bool actual = repo.AddEmployeeDepartmentER(model);
             Assert.IsTrue(actual);
         }
         /// <summary>
         /// Given Incorrect Data To Add To Department Table When Database Is Connected Should Return false
         /// </summary>
         [TestMethod]
         public void GivenIncorrectDataToAddToDepartmentTable_WhenDatabaseIsConnected_ShouldReturnFalse()
         {
             // Act
             EmployeeRepo repo = new EmployeeRepo();
             EmployeeModel model = new EmployeeModel();
             bool actual = repo.AddEmployeeDepartmentER(model);
             // Assert
             Assert.IsFalse(actual);
         }
         /// <summary>
         /// Given correct Data To Add To EmployeePayroll Table When Database Is Connected Should Return True
         /// </summary>
         [TestMethod]
         public void GivencorrectDataToAddToEmployeePayroll_WhenDatabaseIsConnected_ShouldReturnTrue()
         {
             // Act
             EmployeeRepo repo = new EmployeeRepo();
             EmployeeModel model = new EmployeeModel();
             model.basic_Pay = 30000;
             model.Deductions = 1500;
             model.Taxable_Pay = 15000;
             model.Income_tax = 4000;
             model.Net_Pay = 25000;
             model.Id = 3;
             bool actual = repo.AddEmployeePayrollER(model);
             Assert.IsTrue(actual);
         }
         /// <summary>
         /// Given Incorrect Data To Add To EmployeePayroll Table When Database Is Connected Should Return True
         /// </summary>
         [TestMethod]
         public void GivenIncorrectDataToAddToEmployeePayroll_WhenDatabaseIsConnected_ShouldReturnFalse()
         {
             // Act
             EmployeeRepo repo = new EmployeeRepo();
             EmployeeModel model = new EmployeeModel();
             model.basic_Pay = 30000;
             model.Deductions = 1500;
             model.Taxable_Pay = 15000;
             model.Income_tax = 4000;
             model.Net_Pay = 25000;
             bool actual = repo.AddEmployeePayrollER(model);
             // Assert
             Assert.IsFalse(actual);
         }
         /// <summary>
         /// Given Correct Query To DeleteValue When Database Is Connected Should Return True
         /// </summary>
         [TestMethod]
         public void GivenCorrectQueryToDeleteValue_WhenDatabaseIsConnected_ShouldReturnTrue()
         {
             // Act
             EmployeeRepo repo = new EmployeeRepo();
             bool actual = repo.DeleteValue("Employee_Payroll", "Id =3");
             // Assert
             Assert.IsTrue(actual);
         }*/
        /// <summary>
        /// Addings the data to list.
        /// </summary>
        /// <returns></returns>
        public List<EmployeeModel> AddingDataToList()
        {
            List<EmployeeModel> employeeList = new List<EmployeeModel>();
            employeeList.Add(new EmployeeModel
            {
                Name = "Ryan",
                Salary = 750000,
                Start_Date = new System.DateTime(2016, 06, 19),
                Gender = 'M',
                PhoneNumber = "8897221787",
                Address = "Waterloo",
                Department = "developer",
                basic_Pay = 200000,
                Deductions = 30000,
                Taxable_Pay = 400000,
                Income_tax = 20000,
                Net_Pay = 600000
            });
            employeeList.Add(new EmployeeModel
            {
                Name = "Vijay",
                Salary = 500000,
                Start_Date = new System.DateTime(2019, 08, 24),
                Gender = 'M',
                PhoneNumber = "8374154558",
                Address = "Toronto",
                Department = "Design",
                basic_Pay = 200000,
                Deductions = 30000,
                Taxable_Pay = 150000,
                Income_tax = 20000,
                Net_Pay = 420000
            });

            return employeeList;
        }
        /// <summary>
        /// Given  multiple employee data to add without threading when database is connected should return true.
        /// </summary>
        [TestMethod]
        public void GivenMultipleEmployeeDataToAddWithoutThreading_WhenDatabaseIsConnected_ShouldReturnTrue()
        {
            bool expected = true;
            // Act
            List<EmployeeModel> employeeList = AddingDataToList();
            MultiThreadingOperations multiThreading = new MultiThreadingOperations();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            bool actual = multiThreading.AddMultipleEmployeeToDB(employeeList);
            stopwatch.Stop();
            Console.WriteLine("Time taken to add to db without threads is :{0} ms", stopwatch.ElapsedMilliseconds);
            ///Assert
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Compares the time adding to list with or without threading.
        /// </summary>
        [TestMethod]
        public void CompareTimeAddingToListWithOrWithoutThreading()
        {
            List<EmployeeModel> employeeList = AddingDataToList();
            MultiThreadingOperations multiThreading = new MultiThreadingOperations();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            multiThreading.AddToListWithoutThreading(employeeList);
            stopwatch.Stop();
            Console.WriteLine("Time taken while adding to list without threading:{0} ms ", stopwatch.ElapsedMilliseconds);
        }

    }
}