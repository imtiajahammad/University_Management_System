using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem05.businessLogics.ConnectionString;
using UniversityManagementSystem05.Models;

namespace UniversityManagementSystem05.BusinessLogics.CourseAssignLogics
{
    public class CourseAssignGateway: ConnectionString
    {
        public List<int> GetAssignedCreditByTeacherId(int teacherId)
        {
            List<int> courseIdFromAssignedTeachers = new List<int>();
            SqlConnection aSqlConnection = new SqlConnection(connectionString);
            string query = "SELECT courseId FROM courseAssignToTeacher_tbl WHERE teacherId=@teacherId";
            SqlCommand aSqlCommand = new SqlCommand(query, aSqlConnection);
            aSqlCommand.Parameters.Clear();
            aSqlCommand.Parameters.AddWithValue("@teacherId", teacherId);
            aSqlConnection.Open();
            SqlDataReader aSqlDataReader = aSqlCommand.ExecuteReader();

            while (aSqlDataReader.Read())
            {
                courseIdFromAssignedTeachers.Add(Convert.ToInt32(aSqlDataReader["courseId"].ToString()) );
            }
            aSqlConnection.Close();
            return courseIdFromAssignedTeachers;
            
        }


    }
}