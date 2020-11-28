using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeePayrollADO.NET
{
    public class MultiThreadingOperations
    {
        Mutex mutex = new Mutex();
        public List<EmployeeModel> employeeDataList = new List<EmployeeModel>();
        EmployeeRepo repo = new EmployeeRepo();
        /// <summary>
        /// Method adds the values to the table and return true if added or false
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public bool AddEmployee(EmployeeModel model)
        {
            // Gets connection to the database
            SqlConnection connection = DBConnection.GetConnection();
            try
            {
                using (connection)
                {

                    connection.Open();
                    // Created instance of the given query and connection
                    SqlCommand sqlCommand = new SqlCommand("SpAddEmployeeDetails", connection);
                    // Command type  as text for stored procedure
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    // Adds the values to the stored procedure
                    sqlCommand.Parameters.AddWithValue("@Name", model.Name);
                    sqlCommand.Parameters.AddWithValue("@Salary", model.Salary);
                    sqlCommand.Parameters.AddWithValue("@Start_Date", DateTime.Now);
                    sqlCommand.Parameters.AddWithValue("@Gender", model.Gender);
                    sqlCommand.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                    sqlCommand.Parameters.AddWithValue("@Address", model.Address);
                    sqlCommand.Parameters.AddWithValue("@Department", model.Department);
                    sqlCommand.Parameters.AddWithValue("@basic_Pay", model.basic_Pay);
                    sqlCommand.Parameters.AddWithValue("@Deductions", model.Deductions);
                    sqlCommand.Parameters.AddWithValue("@Taxable_Pay", model.Taxable_Pay);
                    sqlCommand.Parameters.AddWithValue("@Income_tax", model.Income_tax);
                    sqlCommand.Parameters.AddWithValue("@Net_Pay", model.Net_Pay);
                    // Returns the number of rows effected
                    var result = sqlCommand.ExecuteNonQuery();
                    connection.Close();
                    // If number of rows not equal to zero then retuns true 
                    // Else returns false
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return false;
        }
        /// <summary>
        /// Adds data to list without threading.
        /// </summary>
        /// <param name="empList">The emp list.</param>
        public void AddToListWithoutThreading(List<EmployeeModel> empList)
        {
            empList.ForEach(employee =>
            {
                Console.WriteLine("Employee being added" + employee.Name);
                this.employeeDataList.Add(employee);
                Console.WriteLine("Employee added: " + employee.Name);
            });
            Console.WriteLine(this.employeeDataList.ToString());
        }
        /// UC 1 multiple threading
        /// <summary>
        ///  Adds the employee to database without multithreading
        /// </summary>
        /// <param name="employeeDetails">The employee details.</param>
        /// <returns></returns>
        public bool AddMultipleEmployeeToDB(List<EmployeeModel> empList)
        {

            foreach (EmployeeModel employee in empList)
            {
                Console.WriteLine("Employee being added" + employee.Name);
                bool result = AddEmployee(employee);
                Console.WriteLine("Employee added: " + employee.Name);
                if (result == false)
                    return false;
            }
            return true;
        }
        /// <summary>
        /// Adds the employee list to database with threading
        /// </summary>
        /// <param name="empList">The emp list.</param>
        /// <returns></returns>
        public bool AddEmployeeListToDBWithThread(List<EmployeeModel> empList)
        {
            bool result = false;
            empList.ForEach(employeeData =>
            {
                Thread thread = new Thread(() =>
                {
                    result = AddEmployee(employeeData);
                    Console.WriteLine("Employee added" + employeeData.Name);
                });
                // Start all the threads
                thread.Start();
                thread.Join();
            });
            return result;

        }
        /// <summary>
        /// Added multiple employee data to list using threading
        /// </summary>
        /// <param name="empList"></param>
        public void AddToListWithThreading(List<EmployeeModel> empList)
        {
            empList.ForEach(employee =>
            {
                Task thread = new Task(() =>
                {
                    Console.WriteLine("Employee Being added" + employee.Name);
                    this.employeeDataList.Add(employee);
                    Console.WriteLine("Employee added: " + employee.Name);
                });
                thread.Start();
            });
        }
        /// UC3
        /// <summary>
        /// Adds the employee to payroll data base with thread in synchronization manner 
        /// </summary>
        /// <param name="employeePayrollDataList">The employee payroll data list.</param>
        public void AddEmployeesWithThreadsAndSynchronization(List<EmployeeModel> employeeDetails)
        {
            employeeDetails.ForEach(employeeData =>
            {
                Thread thread = new Thread(() =>
                {
                    // mutex waitone method is used
                    // this method does not allow to other threads to go in it,
                    // until current thread execution is complete
                    mutex.WaitOne();
                    AddEmployee(employeeData);
                    Console.WriteLine("Employee added" + employeeData.Name);
                    Console.WriteLine("Current Thread Id" + Thread.CurrentThread.ManagedThreadId);
                    // realease mutex is used, which releases current thread and 
                    // allows new thread to be used.
                    mutex.ReleaseMutex();
                });
                // Start all the threads
                thread.Start();
                thread.Join();
            });
        }
        /// <summary>
        /// Adds the employees to list with threads and synchronization.
        /// </summary>
        /// <param name="employeeDetails">The employee details.</param>
        public void AddEmployeesToListWithThreadsAndSynchronization(List<EmployeeModel> employeeDetails)
        {
            employeeDetails.ForEach(employeeData =>
            {
                Thread thread = new Thread(() =>
                {
                    // mutex waitone method is used
                    // this method does not allow to other threads to go in it,
                    // until current thread execution is complete
                    mutex.WaitOne();
                    this.employeeDataList.Add(employeeData);
                    Console.WriteLine("Employee added" + employeeData.Name);
                    Console.WriteLine("Current Thread Id" + Thread.CurrentThread.ManagedThreadId);
                    // realease mutex is used, which releases current thread and 
                    // allows new thread to be used.
                    mutex.ReleaseMutex();
                });
                // Start all the threads
                thread.Start();
                thread.Join();
            });
        }
    }
}
