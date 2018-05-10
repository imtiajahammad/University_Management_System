using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem05.businessLogics.ConnectionString;
using UniversityManagementSystem05.Models;

namespace UniversityManagementSystem05.BusinessLogics.TeacherLogics
{
    public class TeacherGateWay: ConnectionString
    {

        public bool IsTeacherEmailExist(string teacherEmail)
        {
            bool isTeacherEmailExist = false;

            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT teacherEmail FROM teacher_tbl WHERE teacherEmail= @teacherEmail";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Clear();

            //command.Parameters.Add("DeptName", SqlDbType.NVarChar);
            //  command.Parameters["DeptName"].Value = DeptName;
            command.Parameters.AddWithValue("@teacherEmail", teacherEmail);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                isTeacherEmailExist = true;
            }
            connection.Close();

            return isTeacherEmailExist;
        }


        public int SaveTeacher(TeacherModel aTeacherModel)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO teacher_tbl(teacherName,teacherAddress,teacherEmail,teacherNumber,teacherDesignation,teacherDepartment,teacherCreditToBeTaken) VALUES (@teacherName,@teacherAddress,@teacherEmail,@teacherNumber,@teacherDesignation,@teacherDepartment,@teacherCreditToBeTaken)";
            SqlCommand cmd = new SqlCommand(query, connection);


            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@teacherName", aTeacherModel.teacherName);
            cmd.Parameters.AddWithValue("@teacherAddress", aTeacherModel.teacherAddress);
            cmd.Parameters.AddWithValue("@teacherEmail", aTeacherModel.teacherEmail);
            cmd.Parameters.AddWithValue("@teacherNumber", aTeacherModel.teacherName);
            cmd.Parameters.AddWithValue("@teacherDesignation", aTeacherModel.teacherDesignation);
            cmd.Parameters.AddWithValue("@teacherDepartment", aTeacherModel.teacherDepartment);
            cmd.Parameters.AddWithValue("@teacherCreditToBeTaken", aTeacherModel.teacherCreditToBeTacken);
            

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


    }
}