using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem05.Models;

namespace UniversityManagementSystem05.BusinessLogics.CourseLogics
{
    
    public class CourseManager
    {
        CourseGateway aCourseGateway = new CourseGateway();

        public List<string> GetDepartmentCodeList()
        {
            List<string> departmentCodeList = new List<string>();
            departmentCodeList = aCourseGateway.GetDepartmentCodeList();
            return departmentCodeList;
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


    }
}