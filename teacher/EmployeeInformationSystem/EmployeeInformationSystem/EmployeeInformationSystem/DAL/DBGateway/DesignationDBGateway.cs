﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using EmployeeInformationSystem.DAL.DAO;

namespace EmployeeInformationSystem.DAL.DBGateway
{
    class DesignationDBGateway
    {
        string connectionStr = ConfigurationManager.ConnectionStrings["connectionStringForEmployeDB"].ConnectionString;
        private SqlConnection aSqlConnection;
        private SqlCommand aSqlCommand;
        public DesignationDBGateway()
        {
            aSqlConnection = new SqlConnection(connectionStr);
        }

        public void Save(Designation aDesignation)
        {   
            string query = "INSERT INTO tbl_Designation VALUES ('" + aDesignation.Code + "','" + aDesignation.Title 
                + "')";
            aSqlConnection.Open();
            aSqlCommand = new SqlCommand(query, aSqlConnection);
            aSqlCommand.ExecuteNonQuery();
            aSqlConnection.Close();
        }


        public List<Designation> GetAll()
        {
            string query = "SELECT * FROM tbl_designation";
            aSqlConnection.Open();
            aSqlCommand = new SqlCommand(query, aSqlConnection);
            SqlDataReader aDataReader = aSqlCommand.ExecuteReader();
           
            List<Designation> designationList = new List<Designation>();

            while (aDataReader.Read())
            {
                Designation aDesignation = new Designation();
                aDesignation.Id = Convert.ToInt32(aDataReader["Id"]);
                aDesignation.Code = aDataReader["Code"].ToString();
                aDesignation.Title = aDataReader["Title"].ToString();
                designationList.Add(aDesignation);
            }
            aDataReader.Close();
            aSqlConnection.Close();
            return designationList;

        }

        public Designation Find(string code)
        {
            string query = "SELECT * FROM tbl_designation WHERE Code = '" + code +"'";
            aSqlConnection.Open();
            aSqlCommand = new SqlCommand(query, aSqlConnection);
            SqlDataReader aDataReader = aSqlCommand.ExecuteReader();
            Designation aDesignation;

            if (aDataReader.HasRows)
            {
                aDesignation = new Designation();
                aDataReader.Read();
                aDesignation.Id = Convert.ToInt32(aDataReader["Id"]);
                aDesignation.Code = aDataReader["Code"].ToString();
                aDesignation.Title = aDataReader["Title"].ToString();
                aDataReader.Close();
                aSqlConnection.Close();
                return aDesignation;
            }
            else
            {
                aSqlConnection.Close();
                return null;
            }
        }
    }
}
