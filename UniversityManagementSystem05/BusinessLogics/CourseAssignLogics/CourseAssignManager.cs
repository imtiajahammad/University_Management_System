using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem05.BusinessLogics.CourseLogics;
using UniversityManagementSystem05.BusinessLogics.DepartmentLogics;
using UniversityManagementSystem05.BusinessLogics.TeacherLogics;
using UniversityManagementSystem05.Models;

namespace UniversityManagementSystem05.BusinessLogics.CourseAssignLogics
{
    public class CourseAssignManager
    {
        TeacherManager aTeacherManager = new TeacherManager();
        DepartmentManager aDepartmentManager = new DepartmentManager();
        CourseManager aCourseManager = new CourseManager();

        public List<DepartmentModel> GetAllDepartments()
        {
            
            List<DepartmentModel> list = aDepartmentManager.GetAllDepartments();
            return list;
        }
        public List<TeacherModel> GetAllTeachers()
        {            
            return aTeacherManager.GetAllTeachers();
        }
        public List<CourseModel> GetAllCourseCodes()
        {            
            return aCourseManager.ViewAllCourses();
        }
    }
}