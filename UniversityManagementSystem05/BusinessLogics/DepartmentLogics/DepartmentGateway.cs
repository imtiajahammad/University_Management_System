﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem05.businessLogics.ConnectionString;
using UniversityManagementSystem05.Models;

namespace UniversityManagementSystem05.BusinessLogics.DepartmentLogics
{
    public class DepartmentGateway:ConnectionString
    {
        public int SaveDepartment(DepartmentModel aDepartmentModel)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO department_tbl(departmentCode,departmentName) VALUES (@deptCode,@deptName)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@deptCode", aDepartmentModel.departmentCode);
            cmd.Parameters.AddWithValue("@deptName", aDepartmentModel.departmentName);

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

        
        public List<DepartmentModel> GetAllDepartment()
        {
            List<DepartmentModel> departments = new List<DepartmentModel>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM department_tbl";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string DeptCode = reader["departmentCode"].ToString();
                string DeptName = reader["departmentName"].ToString();
                int DeptId = Convert.ToInt32(reader["departmentId"].ToString());
                DepartmentModel aDepartment = new DepartmentModel();
                aDepartment.departmentCode = DeptCode;
                aDepartment.departmentName = DeptName;
                aDepartment.departmentId = DeptId;
                departments.Add(aDepartment);
            }
            connection.Close();
            return departments;
        }

        public bool IsDepartmentCodeExist(string DeptCode)
        {
            bool isDeptCodeExists = false;

            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT departmentCode FROM department_tbl WHERE departmentCode= @DeptCode ";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Clear();

//            command.Parameters.Add("DeptCode", SqlDbType.NVarChar);
//            command.Parameters["DeptCode"].Value = DeptCode;
            command.Parameters.AddWithValue("@DeptCode", DeptCode);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                isDeptCodeExists = true;
            }
            connection.Close();

            return isDeptCodeExists;
        }



        public bool IsDepartmentNameExist(string DeptName)
        {
            bool isDeptNameExists = false;

            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT departmentName FROM department_tbl WHERE departmentName= @DeptName ";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Clear();

            //command.Parameters.Add("DeptName", SqlDbType.NVarChar);
          //  command.Parameters["DeptName"].Value = DeptName;
            command.Parameters.AddWithValue("@DeptName", DeptName);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                isDeptNameExists = true;
            }
            connection.Close();

            return isDeptNameExists;
        }

        public DepartmentModel GetDepartmentForEdit(int DeptId)
        {
            
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM department_tbl WHERE departmentId='"+DeptId+ "'";
            SqlCommand command = new SqlCommand(query, connection);
           // command.Parameters.AddWithValue("@deptId", DeptId);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            DepartmentModel aDepartmentModel = new DepartmentModel();
            while (reader.Read())
            {
                string DeptCode = reader["departmentCode"].ToString();
                string DeptName = reader["departmentName"].ToString();
                int DeptmntId = Convert.ToInt32(reader["departmentId"].ToString());
                
                aDepartmentModel.departmentCode = DeptCode;
                aDepartmentModel.departmentName = DeptName;
                aDepartmentModel.departmentId = DeptId;

            }            
            
            connection.Close();
            return aDepartmentModel;            
        }

        public int UpdateDepartment(DepartmentModel aDepartmentModel)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "UPDATE department_tbl SET departmentCode=@deptCode,departmentName=@deptName WHERE departmentId=@deptId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@deptCode", aDepartmentModel.departmentCode);
            cmd.Parameters.AddWithValue("@deptName", aDepartmentModel.departmentName);
            cmd.Parameters.AddWithValue("@deptId", aDepartmentModel.departmentId);

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

        public int DeleteDepartment(int departmentId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "DELETE FROM department_tbl WHERE departmentId=@deptId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@deptId", departmentId);

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