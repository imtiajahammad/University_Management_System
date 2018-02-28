using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem05.businessLogics.ConnectionString;
using UniversityManagementSystem05.Models;

namespace UniversityManagementSystem05.BusinessLogics.CourseLogics
{
    public class CourseGateway : ConnectionString

    {
        public List<string> GetDepartmentCodeList()
        {
            List<string> departmentCodeList = new List<string>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT departmentCode FROM department_tbl";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string DeptCode = reader["departmentCode"].ToString();


                departmentCodeList.Add(DeptCode);
            }
            connection.Close();
            return departmentCodeList;
        }

        public int SaveCourse(CourseModel aCourseModel)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO course_tbl(courseCode,courseName,courseCredit,courseDescription,courseDepartment,courseSemester) VALUES (@courseCode,@courseName,@courseCredit,@courseDescription,@courseDepartment,@courseSemester)";
            SqlCommand cmd = new SqlCommand(query, connection);

            
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@courseCode", aCourseModel.courseCode);
            cmd.Parameters.AddWithValue("@courseName", aCourseModel.courseName);
            cmd.Parameters.AddWithValue("@courseCredit", aCourseModel.courseCredit);
            if (string.IsNullOrEmpty( aCourseModel.courseDescription))
            {
                cmd.Parameters.AddWithValue("@courseDescription", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@courseDescription", aCourseModel.courseDescription);
            }
            cmd.Parameters.AddWithValue("@courseDepartment", aCourseModel.courseDepartment);
            cmd.Parameters.AddWithValue("@courseSemester", aCourseModel.courseSemester);

            int rowAffected = 0;
            try
            {
                connection.Open();
                rowAffected = cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {

            }
            return rowAffected;
        }


        public bool IsCourseCodeExist(string CourseCode)
        {
            bool isCourseCodeExists = false;

            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT courseCode FROM course_tbl WHERE courseCode= @courseCode ";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Clear();

            command.Parameters.AddWithValue("@courseCode", CourseCode);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                isCourseCodeExists = true;
            }
            connection.Close();

            return isCourseCodeExists;
        }



        public bool IsCourseNameExist(string CourseName)
        {
            bool isCourseNameExists = false;

            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT courseName FROM course_tbl WHERE courseName= @courseName ";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Clear();

            //command.Parameters.Add("DeptName", SqlDbType.NVarChar);
            //  command.Parameters["DeptName"].Value = DeptName;
            command.Parameters.AddWithValue("@courseName", CourseName);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                isCourseNameExists = true;
            }
            connection.Close();

            return isCourseNameExists;
        }


    }
}