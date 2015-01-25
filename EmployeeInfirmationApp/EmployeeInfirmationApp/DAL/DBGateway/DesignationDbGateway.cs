using EmployeeInfirmationApp.DAL.DAO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace EmployeeInfirmationApp.DAL.DBGateway
{
    class DesignationDbGateway
    {
        SqlConnectionManager aSqlConnection = new SqlConnectionManager();
        SqlCommand aSqlCommand = new SqlCommand();

        public void Save(Designation aDesignation)
        {
            string query = "INSERT INTO t_disignation VALUES ('" + aDesignation.Code + "','" + aDesignation.Title 
                + "')";
            aSqlCommand = new SqlCommand(query, aSqlConnection.GetConnection());
            aSqlCommand.ExecuteNonQuery();
            aSqlConnection.CloseConnection();
        }

        public Designation Find(string code)
        {
            string query = "SELECT * FROM t_disignation WHERE Code = '" + code + "'";
            aSqlCommand = new SqlCommand(query, aSqlConnection.GetConnection());
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
                aSqlConnection.GetConnection();
                return aDesignation;
            }
            else
            {
                return null;
            }
        }

        internal List<Designation> GetTitleFromDB()
        {
            List<Designation> designationList = new List<Designation>();
            
            string sqlQuery = "SELECT * FROM t_disignation";
            SqlCommand command = new SqlCommand(sqlQuery, aSqlConnection.GetConnection());
            SqlDataReader aReader = command.ExecuteReader();
            while (aReader.Read())
            {
                Designation aDesignation = new Designation();
                aDesignation.Code = aReader["Code"].ToString();
                aDesignation.Title = aReader["Title"].ToString();
                designationList.Add(aDesignation);
            }
            aSqlConnection.CloseConnection();
            return designationList;
        }

        public bool AddEmployeeToDB(Employee aEmployee)
        {
            
            string sqlQuery = "insert into employee_info values('" + aEmployee.EmployeeName + "', '" +
                                  aEmployee.Email + "', '" + aEmployee.Address + "', '" + aEmployee.Code + "')";
            SqlCommand command = new SqlCommand(sqlQuery, aSqlConnection.GetConnection());
            int effectedRow = command.ExecuteNonQuery();
            aSqlConnection.CloseConnection();
            if(effectedRow>0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public bool CheckDuplicateEmail(string Email)
        {
            string sqlQuery = "SELECT * FROM employee_info WHERE email = '"+Email+"'";
            SqlCommand command = new SqlCommand(sqlQuery, aSqlConnection.GetConnection());
            SqlDataReader aReader = command.ExecuteReader();
            
            bool hasData = aReader.HasRows;
            aSqlConnection.CloseConnection();
            if(hasData)
            {
                return false;
            }
            else
            {
                return true;
            }
        }



        internal List<ViewEmployeeInformation> GetDataFromDatabase(string name)
        {
            List<ViewEmployeeInformation> aDataList = new List<ViewEmployeeInformation>();
            string sqlQuery = "SELECT  em.id, em.name, em.email, dg.Title from employee_info em JOIN t_disignation dg ON em.designation = dg.Code where em.name = '"+name+"'";
            SqlCommand command = new SqlCommand(sqlQuery, aSqlConnection.GetConnection());
            SqlDataReader aReader = command.ExecuteReader();
            while (aReader.Read())
            {
                ViewEmployeeInformation aViewEmployeeInformation = new ViewEmployeeInformation();
                aViewEmployeeInformation.EmployeeId = aReader["id"].ToString();
                aViewEmployeeInformation.Name = aReader["name"].ToString();
                aViewEmployeeInformation.Email = aReader["email"].ToString();
                aViewEmployeeInformation.Designation = aReader["Title"].ToString();
                aDataList.Add(aViewEmployeeInformation);
            }
            aSqlConnection.CloseConnection();
            return aDataList;
        }

        internal List<ViewEmployeeInformation> GetDataFromDatabase(string name, string Code)
        {
            List<ViewEmployeeInformation> aDataList = new List<ViewEmployeeInformation>();
            string sqlQuery = "SELECT  em.id, em.name, em.email, dg.Title from employee_info em JOIN t_disignation dg ON em.designation = dg.Code where em.designation='"+Code+"'";
            SqlCommand command = new SqlCommand(sqlQuery, aSqlConnection.GetConnection());
            SqlDataReader aReader = command.ExecuteReader();
            while (aReader.Read())
            {
                ViewEmployeeInformation aViewEmployeeInformation = new ViewEmployeeInformation();
                aViewEmployeeInformation.EmployeeId = aReader["id"].ToString();
                aViewEmployeeInformation.Name = aReader["name"].ToString();
                aViewEmployeeInformation.Email = aReader["email"].ToString();
                aViewEmployeeInformation.Designation = aReader["Title"].ToString();
                aDataList.Add(aViewEmployeeInformation);
            }
            aSqlConnection.CloseConnection();
            return aDataList;
        }

        internal string GetNumberOfEmployee(string code)
        {
            string sqlQuery = "SELECT COUNT(*) as no FROM employee_info where designation='"+code+"'";
            SqlCommand command = new SqlCommand(sqlQuery, aSqlConnection.GetConnection());
            SqlDataReader aReader = command.ExecuteReader();
            aReader.Read();
            string number = aReader["no"].ToString();
            aSqlConnection.CloseConnection();
            return number;
        }

        internal List<ViewEmployeeInformation> GetAllEmployeeByDepartment()
        {
            List<ViewEmployeeInformation> aEmployeeInformations = new List<ViewEmployeeInformation>();
            string sqlQuery = "select count(*) as Number, t_disignation.Title from employee_info join t_disignation on employee_info.designation = t_disignation.Code group by t_disignation.Title";
            SqlCommand aCommand = new SqlCommand(sqlQuery, aSqlConnection.GetConnection());
            SqlDataReader aReader = aCommand.ExecuteReader();
            while (aReader.Read())
            {
                ViewEmployeeInformation aInformation = new ViewEmployeeInformation();
                aInformation.DepartmentName = aReader["Title"].ToString();
                aInformation.NoOfEmployee = aReader["Number"].ToString();
                aEmployeeInformations.Add(aInformation);
            }
            aSqlConnection.CloseConnection();
            return aEmployeeInformations;
        }
    }
}
