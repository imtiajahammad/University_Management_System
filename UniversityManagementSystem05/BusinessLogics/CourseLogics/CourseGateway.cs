﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem05.businessLogics.ConnectionString;
using UniversityManagementSystem05.BusinessLogics.DepartmentLogics;
using UniversityManagementSystem05.BusinessLogics.SemesterLogics;
using UniversityManagementSystem05.Models;

namespace UniversityManagementSystem05.BusinessLogics.CourseLogics
{
    public class CourseGateway : ConnectionString
    {
        DepartmentManager aDepartmentManager = new DepartmentManager();
        SemesterManager aSemesterManager = new SemesterManager();
        //SqlConnection connection = new SqlConnection(connectionString);
        

        public int SaveCourse(CourseModel aCourseModel)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO course_tbl(courseCode,courseName,courseCredit,courseDescription,departmentId,semesterId) VALUES (@courseCode,@courseName,@courseCredit,@courseDescription,@departmentId,@semesterId)";

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
            cmd.Parameters.AddWithValue("@departmentId", aCourseModel.departmentId);
            cmd.Parameters.AddWithValue("@semesterId", aCourseModel.semesterId);

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

        public List<CourseModel> GetAllCourses()
        {
            List<CourseModel> courses = new List<CourseModel>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM course_tbl";
            //string query = "SELECT course_tbl.courseId, course_tbl.courseCode,course_tbl.courseName, " +
            //    "course_tbl.courseCredit, course_tbl.courseDescription, department_tbl.departmentName, " +
            //    "semester_tbl.semester FROM course_tbl " +
            //    "INNER JOIN department_tbl ON department_tbl.departmentId = course_tbl.departmentId " +
            //    "INNER JOIN semester_tbl ON semester_tbl.id = course_tbl.semesterId; ";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                CourseModel aCourseModel = new CourseModel();
                aCourseModel.courseId = Convert.ToInt32(reader["courseId"].ToString());
                aCourseModel.courseCode = reader["courseCode"].ToString();
                aCourseModel.courseName = reader["courseName"].ToString();
                aCourseModel.courseCredit = Convert.ToInt32(reader["courseCredit"].ToString());
                aCourseModel.courseDescription = reader["courseDescription"].ToString();
                aCourseModel.departmentId = int.Parse(reader["departmentId"].ToString());
                aCourseModel.semesterId= int.Parse(reader["semesterId"].ToString());
                aCourseModel.Department = aDepartmentManager.GetDepartmentById(aCourseModel.departmentId);
                aCourseModel.Semester = aSemesterManager.GetSemesterById(aCourseModel.semesterId);
                courses.Add(aCourseModel);
            }
            
            connection.Close();
            return courses;
        }



        public CourseModel GetCourseForEdit(int courseId)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM course_tbl WHERE courseId='" + courseId + "'";
            SqlCommand command = new SqlCommand(query, connection);
            // command.Parameters.AddWithValue("@deptId", DeptId);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            CourseModel aCourseModel = new CourseModel();
            while (reader.Read())
            {
                aCourseModel.courseId = Convert.ToInt32(reader["courseId"].ToString());
                aCourseModel.courseCode = reader["courseCode"].ToString();
                aCourseModel.courseName = reader["courseName"].ToString();
                aCourseModel.courseCredit = Convert.ToInt32(reader["courseCredit"].ToString());
                aCourseModel.courseDescription = reader["courseDescription"].ToString();
                aCourseModel.departmentId = int.Parse(reader["departmentId"].ToString());
                aCourseModel.semesterId = int.Parse(reader["semesterId"].ToString());
            }
            aCourseModel.Department = aDepartmentManager.GetDepartmentById(aCourseModel.departmentId);
            aCourseModel.Semester = aSemesterManager.GetSemesterById(aCourseModel.semesterId);

            connection.Close();
            return aCourseModel;
        }




        public int DeleteCourse(int courseId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "DELETE FROM course_tbl WHERE courseId=@courseId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@courseId", courseId);

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

        public int UpdateCourse(CourseModel aCourseModel)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "UPDATE course_tbl SET courseCode=@courseCode,courseName=@courseName,courseCredit=@courseCredit,courseDescription=@courseDescription,courseDepartment=@courseDepartment,courseSemester=@courseSemester WHERE courseId=@courseId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@courseCode", aCourseModel.courseCode);
            cmd.Parameters.AddWithValue("@courseName", aCourseModel.courseName);
            cmd.Parameters.AddWithValue("@courseCredit", aCourseModel.courseCredit);
            if (string.IsNullOrEmpty(aCourseModel.courseDescription))
            {
                cmd.Parameters.AddWithValue("@courseDescription", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@courseDescription", aCourseModel.courseDescription);
            }
            cmd.Parameters.AddWithValue("@courseDepartment", aCourseModel.departmentId);
            cmd.Parameters.AddWithValue("@courseSemester", aCourseModel.semesterId);
            cmd.Parameters.AddWithValue("@courseId", aCourseModel.courseId);
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

        public List<string> GetCourseCodeList()
        {
            List<string> courseCodeList = new List<string>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT courseCode FROM course_tbl";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string DeptCode = reader["courseCode"].ToString();


                courseCodeList.Add(DeptCode);
            }
            connection.Close();
            return courseCodeList;
        }

        public List<string> GetCourseNameByCourseCode(string courseCode)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT courseName,courseCredit FROM course_tbl WHERE courseCode=@courseCode";
            SqlCommand commaand = new SqlCommand(query, connection);
            commaand.Parameters.Clear();
            commaand.Parameters.AddWithValue("@courseCode", courseCode);
            connection.Open();
            SqlDataReader aSqlDataReader = commaand.ExecuteReader();
            string courseName = aSqlDataReader["courseName"].ToString();
            int courseCredit = Convert.ToInt32(aSqlDataReader["courseCredit"].ToString());
            List<string> list = new List<string>();
            list.Add(courseName);
            list.Add(courseCredit.ToString());
            return list;
        }

        public List<string> GetCourseNameCreditByDept(string dept)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT courseName,courseCredit FROM course_tbl WHERE courseDepartment=@courseDepartment";
            SqlCommand commaand = new SqlCommand(query, connection);
            commaand.Parameters.Clear();
            commaand.Parameters.AddWithValue("@courseDepartment", dept);
            connection.Open();
            SqlDataReader aSqlDataReader = commaand.ExecuteReader();
            if (aSqlDataReader.HasRows)
            {
                string courseName = aSqlDataReader["courseName"].ToString();
                int courseCredit = Convert.ToInt32(aSqlDataReader["courseCredit"].ToString());
                List<string> list = new List<string>();
                list.Add(courseName);
                list.Add(courseCredit.ToString());
                return list;
            }
            else
            {
                return null;
            }
        }
    }
}