﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem05.businessLogics.ConnectionString;
using UniversityManagementSystem05.Models;

namespace UniversityManagementSystem05.BusinessLogics.DesignationLogics
{
    public class DesignationGateway : ConnectionString
    {
        public List<DesignationModel> GetAllDesignations()
        {
            List<DesignationModel> designationsList = new List<DesignationModel>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM designation_tbl";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                DesignationModel aDesignationModel = new DesignationModel();
                aDesignationModel.DesignationId = int.Parse(reader["id"].ToString());
                aDesignationModel.Designation = reader["designation"].ToString();
                designationsList.Add(aDesignationModel);
            }
            connection.Close();
            return designationsList;
        }
        public DesignationModel GetDesignationById(int designationId)
        {
            DesignationModel aDesignationModel = new DesignationModel();
            SqlConnection aSqlConnection = new SqlConnection(connectionString);
            string query = "SELECT * FROM designation_tbl";
            SqlCommand aSqlCommand = new SqlCommand(query, aSqlConnection);
            aSqlConnection.Open();
            SqlDataReader aSqlDataReader = aSqlCommand.ExecuteReader();
            while (aSqlDataReader.Read())
            {
                aDesignationModel.DesignationId = int.Parse(aSqlDataReader["id"].ToString());
                aDesignationModel.Designation = aSqlDataReader["designation"].ToString();
            }
            aSqlConnection.Close();
            return aDesignationModel;

        }


    }
}