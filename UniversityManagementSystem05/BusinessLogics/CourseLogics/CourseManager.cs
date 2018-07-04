using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem05.BusinessLogics.DepartmentLogics;
using UniversityManagementSystem05.Models;

namespace UniversityManagementSystem05.BusinessLogics.CourseLogics
{
    
    public class CourseManager
    {
        CourseGateway aCourseGateway = new CourseGateway();
        DepartmentGateway aDepartmentGateway = new DepartmentGateway();

        public List<CourseModel> ViewAllCourses()
        {
            List<CourseModel> courses = new List<CourseModel>();
            courses = aCourseGateway.GetAllCourses();
            return courses;
        }

        public List<string> GetAllSemesters()
        {
            List<string> semesters = new List<string>();
            semesters = aCourseGateway.GetAllSemesters();
            return semesters;
        }


        public int UpdateDepartment(CourseModel aCourseModel)
        {
            {
                int rowAffected = aCourseGateway.UpdateCourse(aCourseModel);
                return rowAffected;
            }


        }


        public List<string> GetDepartmentCodeList()
        {
            List<string> departmentCodeList = new List<string>();
            departmentCodeList = aDepartmentGateway.GetDepartmentCodeList();
            return departmentCodeList;
        }
        public List<string> GetCourseNameCourseCode(string courseCode)
        {
            return aCourseGateway.GetCourseNameByCourseCode(courseCode);
        }

        public string SaveCourse(CourseModel aCourseModel)
        {
            string message = "";
            if (aCourseGateway.IsCourseCodeExist(aCourseModel.courseCode)) 
            {
                message = "Course Code Exists";
            }
            else if (aCourseGateway.IsCourseNameExist(aCourseModel.courseName))//  aDepartmentGateway.IsDepartmentNameExist(aDepartmetModel.departmentName))
            {
                message = "Course Name Exists";
            }
            else
            {
                int rowAffected =aCourseGateway.SaveCourse(aCourseModel);// aDepartmentGateway.SaveDepartment(aDepartmetModel);
                if (rowAffected > 0)
                {
                    message = "Course Saved Successfully";
                }
                else
                {
                    message = "Sorry! Course Save Failed !!";
                }
            }
            return message;
        }

        public CourseModel GetCourseForEdit(int courseId)
        {
            CourseModel aCourseModel = new CourseModel();
            aCourseModel = aCourseGateway.GetCourseForEdit(courseId);
            return aCourseModel;
        }

        public int DeleteCourse(int courseId)
        {
            //          string message = "";

            int rowAffected = aCourseGateway.DeleteCourse(courseId);


            //return message;
            return rowAffected;
        }

    }
}