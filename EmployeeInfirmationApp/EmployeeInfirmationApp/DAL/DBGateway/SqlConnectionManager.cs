using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeInfirmationApp.DAL.DBGateway
{
    class SqlConnectionManager
    {
        private SqlConnection aSqlConnection;

        public SqlConnection GetConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EmployeeInformation"].ConnectionString;
            aSqlConnection = new SqlConnection(connectionString);
            aSqlConnection.Open();
            return aSqlConnection;
        }

        public void CloseConnection()
        {
            if (aSqlConnection != null)
            {
                aSqlConnection.Close();
            }
        }
    }
}
