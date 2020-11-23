using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayrollADO.NET
{
    class EmployeeRepo
    {
        // Connecting string for connection to database 
        public static string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = Payroll_Service; Integrated Security = True";
        SqlConnection connection = new SqlConnection(connectionString);
    }
}
