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
        /// <summary>
        /// Method Reads the data from the table and prints the values
        /// </summary>
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
        /// <summary>
        /// Method adds the values to the table and return true if added or false
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public bool AddEmployee(EmployeeModel model)
        {

            try
            {
                using (this.connection)
                {
                    SqlCommand sqlCommand = new SqlCommand("SpAddEmployeeDetails", this.connection);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
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
                    this.connection.Open();
                    var result = sqlCommand.ExecuteNonQuery();
                    this.connection.Close();
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
                this.connection.Close();
            }
            return false;
        }
        /// <summary>
        /// Updates the table value for the given condition
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool UpdateTables( string updateQuery)
        {
            using (this.connection)
            {
                try
                {
                    this.connection.Open();
                    SqlCommand command = this.connection.CreateCommand();
                    command.CommandText = updateQuery;
                    int numberOfEffectedRows = command.ExecuteNonQuery();
                    if (numberOfEffectedRows != 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    this.connection.Close();
                }
            }
        }
    }
}
