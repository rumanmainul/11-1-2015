﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeInformationSystem.DAL.DAO;

namespace EmployeeInformationSystem.DAL.DBGateway
{
    class EmployeeDBGateway
    {
        string connectionStr = ConfigurationManager.ConnectionStrings["connectionStringForEmployeDB"].ConnectionString;
        private SqlConnection aSqlConnection;
        private SqlCommand aSqlCommand;
        public EmployeeDBGateway()
        {
            aSqlConnection = new SqlConnection(connectionStr);
        }

        public void Save(Employee anEmployee)
        {

        }
    }
}
