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
                    // Query for retriving all the data
                    string query = "Select * from Employee_Payroll";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    // Reads the passed data base
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
                            // Prints the retrived values
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
                    // Created instance of the given query and connection
                    SqlCommand sqlCommand = new SqlCommand("SpAddEmployeeDetails", this.connection);
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
                    this.connection.Open();
                    // Returns the number of rows effected
                    var result = sqlCommand.ExecuteNonQuery();
                    this.connection.Close();
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
                this.connection.Close();
            }
            return false;
        }
        /// <summary>
        /// Updates the table value for the given condition
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool UpdateTables(string updateQuery)
        {
            using (this.connection)
            {
                try
                {
                    this.connection.Open();
                    SqlCommand command = this.connection.CreateCommand();
                    // Takes command type as text
                    command.CommandText = updateQuery;
                    // Returns number of rows effected
                    int numberOfEffectedRows = command.ExecuteNonQuery();
                    // If number of rows not equal to zero then retuns true 
                    // Else returns false
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
        /// <summary>
        /// Method displays Sums  of the basic pay gender wise.
        /// </summary>
        public void SumOfSalaryGenderWise()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    // Query for retriving sum as basic pay gender wise
                    string query = @"SELECT gender,sum(basic_pay) as CombineSalary from Employee_Payroll  group by gender";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    // Creates instance for data reader
                    SqlDataReader dataReader = command.ExecuteReader();
                    // Creates instance for data reader
                    if (dataReader.HasRows)
                    {
                        // Reads all the data in table
                        while (dataReader.Read())
                        {
                            // Prints the "0" and "1" column for gender and aggregate basic pay respectively
                            Console.Write(dataReader.GetString(0) + "\t");
                            Console.Write(dataReader.GetDecimal(1) + "\t");
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
        /// <summary>
        /// Method displays  Average  of salary gender wise.
        /// </summary>
        public void AverageOfSalaryGenderWise()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    // Query for retriving average of  basic pay gender wise
                    string query = @"select gender, AVG(basic_pay) from Employee_Payroll group by gender";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    // Creates instance for data reader
                    SqlDataReader dataReader = command.ExecuteReader();
                    // Creates instance for data reader
                    if (dataReader.HasRows)
                    {
                        // Reads all the data in table
                        while (dataReader.Read())
                        {
                            // Prints the "0" and "1" column for gender and average of basic pay respectively
                            Console.Write(dataReader.GetString(0) + "\t");
                            Console.Write(dataReader.GetDecimal(1));
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
        /// <summary>
        /// Method displays Minimum  salary gender wise.
        /// </summary>
        public void MinimumSalaryGenderWise()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    // Query for retriving minimum of  basic pay gender wise
                    string query = @"select gender, MIN(basic_pay) from Employee_Payroll group by gender";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            // Prints the "0" and "1" column for gender and minimum of basic pay respectively
                            Console.Write(dataReader.GetString(0) + "\t");
                            Console.Write(dataReader.GetDecimal(1));
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
        /// <summary>
        /// Method displays Maximum  basic pay gender wise.
        /// </summary>
        public void MaximumSalaryGenderWise()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    // Query for retriving Maximum of  basic pay gender wise
                    string query = @"select gender, MAX(basic_pay) from Employee_Payroll group by gender";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            // Prints the "0" and "1" column for gender and Maximum of basic pay respectively
                            Console.Write(dataReader.GetString(0) + "\t");
                            Console.Write(dataReader.GetDecimal(1));
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
        /// <summary>
        /// Counts the of employees gender wise.
        /// </summary>
        public void CountOfEmployeesGenderWise()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    // Query for retriving count of  employees gender wise
                    string query = @"select gender, COUNT(gender) from Employee_Payroll group by gender";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            // Prints the "0" and "1" column for gender and count of gender respectively
                            Console.Write(dataReader.GetString(0) + "\t");
                            Console.Write(dataReader.GetInt32(1));
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
