﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem05.BusinessLogics.DepartmentLogics;
using UniversityManagementSystem05.BusinessLogics.DesignationLogics;
using UniversityManagementSystem05.Models;

namespace UniversityManagementSystem05.BusinessLogics.TeacherLogics
{
    public class TeacherManager
    {
        TeacherGateWay aTeacherGateWay = new TeacherGateWay();
        DepartmentGateway aDepartmentGateway = new DepartmentGateway();
        DesignationGateway aDesignationGateway = new DesignationGateway();
        public string SaveTeacher(TeacherModel aTeacherModel)
        {
            string message = "";
            if (aTeacherGateWay.IsTeacherEmailExist(aTeacherModel.TeacherEmail))
            {
                message = "Teacher Email Exists";
            }
            else
            {
                int rowAffected = aTeacherGateWay.SaveTeacher(aTeacherModel);// aDepartmentGateway.SaveDepartment(aDepartmetModel);
                if (rowAffected > 0)
                {
                    message = "Teacher Saved Successfully";
                }
                else
                {
                    message = "Sorry! Teacher Save Failed !!";
                }
            }
            return message;
        }

        public List<string> GetAllDepartmentCodes()
        {
            List<string> listOfDepartmentCode = new List<string>();
            listOfDepartmentCode = aDepartmentGateway.GetDepartmentCodeList();
            return listOfDepartmentCode;
        }

        public List<TeacherModel> GetTeachersByDepartmentId(int dept)
        {
            TeacherGateWay aTeacherGateWay = new TeacherGateWay();
            List<TeacherModel> teachers = new List<TeacherModel>();
            teachers = aTeacherGateWay.GetTeacherwithByDept(dept);
            return teachers;
        }

        public int GetCreditByTeacherId(int teacherId)
        {
            TeacherGateWay aTeacherGateWay = new TeacherGateWay();
            return aTeacherGateWay.GetCreditByTeacherId(teacherId);
        }

        public int getAssignedCreditByTeacherId(int teacherId)
        {
            TeacherGateWay aTeacherGateWay = new TeacherGateWay();
            return aTeacherGateWay.getAssignedCreditByTeacherName(teacherId);
        }


        public List<DesignationModel> GetAllDesignations()
        {
            List<DesignationModel> designations = new List<DesignationModel>();
            designations = aDesignationGateway.GetAllDesignations();
            return designations;
        }

        public List<TeacherModel> GetAllTeachers()
        {
            List<TeacherModel> teachers = aTeacherGateWay.GetAllTeachers();
            return teachers;
        }

        public int UpdateTeacher(TeacherModel aTeacherModel)
        {
            //{
                
                //if (aTeacherGateWay.IsTeacherEmailExist(aTeacherModel.teacherEmail))
                //{
                //    return 5;
                //}
                //else
                //{
                    int rowAffected = aTeacherGateWay.UpdateTeacher(aTeacherModel);
                    return rowAffected;
            //    }
                
            //}
        }

        public TeacherModel GetTeacherForEdit(int teacherId)
        {
            TeacherModel aTeacherModel = new TeacherModel();
            aTeacherModel = aTeacherGateWay.GetTeacherForEdit(teacherId);
            return aTeacherModel;
        }

        public int DeleteTeacher(int deleteId)
        {
            //          string message = "";
            int rowAffected = aTeacherGateWay.DeleteTeacher(deleteId);
            //return message;
            return rowAffected;
        }

    }

}