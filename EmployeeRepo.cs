using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayrollADO.NET
{
    public class EmployeeRepo
    {
        // Connecting string for connection to database 
        public static string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = Payroll_Service; Integrated Security = True";
        SqlConnection connection = new SqlConnection(connectionString);
        public void GetAllEmployee()
        {
            try
            {
                EmployeeModel model = new EmployeeModel();
                using (this.connection)
                {
                    string query = "Select * from Employee_Payroll";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            model.Id = dataReader.GetInt32(0);
                            model.Name = dataReader.GetString(1);
                            model.Salary = dataReader.GetDecimal(2);
                            model.Start_Date = dataReader.GetDateTime(3);
                            model.Gender = Convert.ToChar(dataReader.GetString(4));
                            model.PhoneNumber = dataReader.GetString(5);
                            model.Address = dataReader.GetString(6);
                            model.Department = dataReader.GetString(7);
                            model.basic_Pay = dataReader.GetDecimal(8);
                            model.Deductions = dataReader.GetDecimal(9);
                            model.Taxable_Pay = dataReader.GetDecimal(10);
                            model.Income_tax = dataReader.GetDecimal(11);
                            model.Net_Pay = dataReader.GetDecimal(12);
                            Console.WriteLine(model.Id + " " + model.Name + " " + model.basic_Pay + " " + model.Start_Date + " " + model.Gender + " " + model.PhoneNumber + " " + model.Address + " " + model.Department + " " + model.Deductions + " " + model.Taxable_Pay + " " + model.Income_tax + " " + model.Net_Pay);
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                    dataReader.Close();
                    this.connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
