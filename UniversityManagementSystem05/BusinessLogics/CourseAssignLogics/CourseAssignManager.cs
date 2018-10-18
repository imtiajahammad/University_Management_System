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
        CourseAssignGateway aCourseAssignGateway = new CourseAssignGateway();

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

        public List<TeacherModel> GetTeachersByDeptId(int deptId)
        {
            return aTeacherManager.GetTeachersByDepartmentId(deptId);
        }
        public List<CourseModel> GetCourseListByDeptId(int deptId)
        {
            return aCourseManager.GetCourseListByDeptId(deptId);
        }
        public int GetCreditByTeacherId(int teacherId)
        {
            int creditToBeTaken = aTeacherManager.GetCreditByTeacherId(teacherId);
            return creditToBeTaken;
        }
        
        public CourseModel GetCourseModelByCourseId(int courseId)
        {
            CourseModel aCourseModel = aCourseManager.GetCourseModelByCourseId(courseId);
            return aCourseModel;
        }
        public int GetAssignedCreditByTeacherId(int teacherId)
        {
            List<int> courseIdFromAssignedTeachers = new List<int>();
            courseIdFromAssignedTeachers = aCourseAssignGateway.GetAssignedCreditByTeacherId(teacherId);
            int totalAssignedCredit = GetTotalAssignedCreditFromAssignedTeachers(courseIdFromAssignedTeachers);

            return totalAssignedCredit;
        }
        public int GetTotalAssignedCreditFromAssignedTeachers(List<int> courseIdFromAssignedTeachers)
        {
            int total = 0;
            if (courseIdFromAssignedTeachers.Count >0)
            {
                foreach(int i in courseIdFromAssignedTeachers)
                {
                    total += aCourseManager.GetCourseCreditByCourseId(i);
                }

                return total;
            }
            else
            {
                return 0;
            }

        }
    }
}