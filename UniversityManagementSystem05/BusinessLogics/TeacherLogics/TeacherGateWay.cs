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

            string query = "SELECT teacherEmail FROM teacher_tbl WHERE teacherEmail=@teacherEmail";
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
            cmd.Parameters.AddWithValue("@teacherNumber", aTeacherModel.teacherNumber);
            cmd.Parameters.AddWithValue("@teacherDesignation", aTeacherModel.teacherDesignation);
            cmd.Parameters.AddWithValue("@teacherDepartment", aTeacherModel.teacherDepartment);
            cmd.Parameters.AddWithValue("@teacherCreditToBeTaken", aTeacherModel.teacherCreditToBeTaken);
            

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

        public List<TeacherModel> GetAllTeachers()
        {
            List<TeacherModel> teachers = new List<TeacherModel>();
            SqlConnection connection = new SqlConnection(connectionString);  
            string query = "SELECT * FROM teacher_tbl";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                TeacherModel aTeacherModel = new TeacherModel();
                aTeacherModel.teacherId= Convert.ToInt32(reader["teacherId"].ToString());
                aTeacherModel.teacherName = reader["teacherName"].ToString();
                aTeacherModel.teacherAddress = reader["teacherAddress"].ToString();
                aTeacherModel.teacherEmail = reader["teacherEmail"].ToString();
                aTeacherModel.teacherNumber = reader["teacherNumber"].ToString();
                aTeacherModel.teacherDesignation = reader["teacherDesignation"].ToString();
                aTeacherModel.teacherDepartment = reader["teacherDepartment"].ToString();
                aTeacherModel.teacherCreditToBeTaken = Convert.ToInt32(reader["teacherCreditToBeTaken"].ToString());
                teachers.Add(aTeacherModel);
            }
            connection.Close();
            return teachers;
        }

        public TeacherModel GetTeacherForEdit(int teacherId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM teacher_tbl WHERE teacherId='" + teacherId + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            TeacherModel aTeacherModel = new TeacherModel();
            while (reader.Read())
            {
                aTeacherModel.teacherId = Convert.ToInt32(reader["teacherId"].ToString());
                aTeacherModel.teacherName = reader["teacherName"].ToString();
                aTeacherModel.teacherAddress = reader["teacherAddress"].ToString();
                aTeacherModel.teacherEmail = reader["teacherEmail"].ToString();
                aTeacherModel.teacherNumber = reader["teacherNumber"].ToString();
                aTeacherModel.teacherDesignation = reader["teacherDesignation"].ToString();
                aTeacherModel.teacherDepartment = reader["teacherDepartment"].ToString();
                aTeacherModel.teacherCreditToBeTaken = Convert.ToInt32(reader["teacherCreditToBeTaken"].ToString());
            }
            connection.Close();
            return aTeacherModel;
        }


        public List<string> GetTeacherwithByDept(string department)
        {
            List<string> teachers = new List<string>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT teacherName FROM teacher_tbl WHERE teacherDepartment='" + department + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string getDepartment= reader["teacherName"].ToString();
                teachers.Add(getDepartment);
            }
            connection.Close();
            return teachers;
        }

        public int GetCreditByTeacherName(string teacherName)
        {
            //List<string> teachers = new List<string>();
            int credit = 0;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT teacherCreditToBeTaken FROM teacher_tbl WHERE teacherName=@teacherName";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@teacherName", teacherName);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows) {
                while (reader.Read())
                {
                    credit = Convert.ToInt32(reader["teacherCreditToBeTaken"].ToString());
                }
            }
            connection.Close();
            return credit;
        }
        public int getAssignedCreditByTeacherName(string teacherName)
        {
                SqlConnection aSqlConnection = new SqlConnection(connectionString);
                string query = "SELECT courseCredit FROM courseAssignToTeacher_tbl WHERE teacher=@teacher";
                SqlCommand aSqlCommand = new SqlCommand(query,aSqlConnection);
                aSqlCommand.Parameters.Clear();
                aSqlCommand.Parameters.AddWithValue("@teacher", teacherName);
                aSqlConnection.Open();
                SqlDataReader aSqlDataReader = aSqlCommand.ExecuteReader();
                if (aSqlDataReader.HasRows)
                {
                    int assignedCredit = 0;
                    while (aSqlDataReader.Read())
                    {
                        assignedCredit += Convert.ToInt32(aSqlDataReader["courseCredit"].ToString());
                    }
                    aSqlConnection.Close();
                    return assignedCredit;
                }
                else
                {
                    aSqlConnection.Close();
                    return 0;
                }
        }
        //public bool getCreditAssignedToTeacher(string teacherName)
        //{
        //    SqlConnection aSqlConnection = new SqlConnection(connectionString);
        //    string query = "SELECT courseCredit FROM courseAssignToTeacher_tbl WHERE teacher=@teacher";
        //    SqlCommand aSqlCommand = new SqlCommand(query, aSqlConnection);
        //    aSqlCommand.Parameters.Clear();
        //    aSqlCommand.Parameters.AddWithValue("@teacher",teacherName);
        //    aSqlConnection.Open();
        //    SqlDataReader aSqlDataReader = aSqlCommand.ExecuteReader();
        //    if (aSqlDataReader.HasRows)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}


        public int DeleteTeacher(int teacherId)
        {
            SqlConnection connection= new SqlConnection(connectionString);
            string query = "DELETE FROM teacher_tbl WHERE teacherId=@teacherId";
            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@teacherId", teacherId);
            int rowAffected = 0;
            try
            {
                connection.Open();
                rowAffected = command.ExecuteNonQuery();
                connection.Close();
            }
            catch(Exception e)
            {
            }
            return rowAffected;
        }

        public int UpdateTeacher(TeacherModel aTeacherModel)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "UPDATE teacher_tbl SET teacherName=@teacherName,teacherAddress=@teacherAddress,teacherEmail=@teacherEmail,teacherNumber=@teacherNumber,teacherDesignation=@teacherDesignation,teacherDepartment=@teacherDepartment,teacherCreditToBeTaken=@teacherCreditToBeTaken WHERE teacherId=@teacherId";
            SqlCommand commmand = new SqlCommand(query, connection);
            commmand.Parameters.Clear();
            commmand.Parameters.AddWithValue("@teacherName",aTeacherModel.teacherName);
            commmand.Parameters.AddWithValue("@teacherAddress",aTeacherModel.teacherAddress);
            commmand.Parameters.AddWithValue("@teacherEmail", aTeacherModel.teacherEmail);
            commmand.Parameters.AddWithValue("@teacherNumber", aTeacherModel.teacherNumber);
            commmand.Parameters.AddWithValue("@teacherDesignation", aTeacherModel.teacherDesignation);
            commmand.Parameters.AddWithValue("@teacherDepartment", aTeacherModel.teacherDepartment);
            commmand.Parameters.AddWithValue("@teacherCreditToBeTaken", aTeacherModel.teacherCreditToBeTaken);
            commmand.Parameters.AddWithValue("@teacherId",aTeacherModel.teacherId);
            int rowAffected = 0;
            try
            {
                connection.Open();
                rowAffected = commmand.ExecuteNonQuery();
                connection.Close();
            }
            catch(Exception e)
            {

            }
            return rowAffected;
        }

        public List<string> GetAllDesignations()
        {
            List<string> designationsList = new List<string>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM designation_tbl";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                designationsList.Add(reader["designation"].ToString());
            }
            connection.Close();
            return designationsList;
        }
    }
}