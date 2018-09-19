using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem05.businessLogics.ConnectionString;
using UniversityManagementSystem05.Models;

namespace UniversityManagementSystem05.BusinessLogics.SemesterLogics
{
    public class SemesterGateway:ConnectionString
    {

        public List<SemesterModel> GetAllSemesters()
        {
            List<SemesterModel> semestersList = new List<SemesterModel>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM semester_tbl";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                SemesterModel aSemesterModel = new SemesterModel();
                aSemesterModel.semesterId = Convert.ToInt32(reader["id"]);
                aSemesterModel.semesterName = reader["semester"].ToString();
                semestersList.Add(aSemesterModel);
            }
            connection.Close();
            return semestersList;
        }
        public SemesterModel GetSemesterById(int semesterId)
        {
            SemesterModel aSemesterModel = new SemesterModel();
            SqlConnection aSqlConnection = new SqlConnection(connectionString);
            string query = "SELECT * FROM semester_tbl WHERE id=@id";

            SqlCommand aSqlCommand = new SqlCommand(query, aSqlConnection);

            aSqlCommand.Parameters.Clear();

            aSqlCommand.Parameters.AddWithValue("@id", semesterId);
            aSqlConnection.Open();
            SqlDataReader aSqlDataReader = aSqlCommand.ExecuteReader();
            while (aSqlDataReader.Read())
            {
                aSemesterModel.semesterId = Convert.ToInt32(aSqlDataReader["id"]);
                aSemesterModel.semesterName = aSqlDataReader["semester"].ToString();
            }
            return aSemesterModel;
        }

    }
}