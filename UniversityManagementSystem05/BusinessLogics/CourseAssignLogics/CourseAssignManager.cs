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



        /// <summary>
        /// calling GetAllDepartments()  function from CourseAssignManager;
        /// that GetAllDepartments()  Function calls GetAllDepartments() function From DepartmentManager;
        /// that GetAllDepartments()  Function calls GetAllDepartments() function From DepartmentGateway;
        /// that GetAllDepartments()  gets all the departments with id,names from database;
        /// </summary>
        /// <returns>all the departments with id,names from database.</returns>
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

        /// <summary>
        /// takes id and fetch list of assign credit list 
        /// then uses GetTotalAssignedCreditFromAssignedTeachers method to get total 
        /// </summary>
        /// <param name="teacherId"></param>
        /// <returns>total assigned credit</returns>
        public int GetAssignedCreditByTeacherId(int teacherId)
        {
            List<int> courseIdFromAssignedTeachers = new List<int>();
            courseIdFromAssignedTeachers = aCourseAssignGateway.GetAssignedCreditByTeacherId(teacherId);
            int totalAssignedCredit = GetTotalAssignedCreditFromAssignedTeachers(courseIdFromAssignedTeachers);

            return totalAssignedCredit;
        }
        /// <summary>
        /// takes list of integer and returns summation of them
        /// </summary>
        /// <param name="courseIdFromAssignedTeachers"></param>
        /// <returns> "sum of integers in int type"</returns>
        public int GetTotalAssignedCreditFromAssignedTeachers(List<int> courseIdFromAssignedTeachers)
        {
            //error
            //I am making an addition to courseId list
            //imtiaj 
            int total = 0;
            if (courseIdFromAssignedTeachers.Count > 0)
            {
                foreach (int i in courseIdFromAssignedTeachers)
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
        public bool IsCourseExist(int courseID)
        {
            bool isCourseExists = aCourseAssignGateway.IsCourseExist(courseID);
            return isCourseExists;
        }
        public int DeleteAssignedCourseByCourseAssignId(int AssignedCourseId)
        {
            //          string message = "";

            int rowAffected = aCourseAssignGateway.DeleteAssignedCourseByAssignedCourseId(AssignedCourseId);


            //return message;
            return rowAffected;
        }
        public int UpdateAssignedCourseToTeacherModel(CourseAssignToTeacherModel aCourseAssignToTeacherModel)
        {
            {
                int rowAffected = aCourseAssignGateway.UpdateCourseAssign(aCourseAssignToTeacherModel);
                return rowAffected;
            }
        }
        public CourseAssignToTeacherModel GetAssignedCourseToTeacherModelById(int assignedCourseId)
        {
            CourseAssignToTeacherModel aCourseAssignToTeacherModel = aCourseAssignGateway.GetSingleCourseAssignToTeacherModel(assignedCourseId);
            return aCourseAssignToTeacherModel;
        }
        public int SaveCourseAssignToTeacher(CourseAssignToTeacherModel courseAssignToTeacherModel)
        {

            int input = aCourseAssignGateway.SaveCourseAssignToTeacher(courseAssignToTeacherModel);
            return input;

        }
        public DepartmentModel GetSingleDepartmentByDeptId(int deptId)
        {
            return aDepartmentManager.GetDepartmentById(deptId);
        }
        public TeacherModel GetSingleTeacherByTeacherId(int TeacherId)
        {
            return aTeacherManager.GetTeacherByTeacherId(TeacherId);
        }
        public CourseModel GetSingleCourseByCourseId(int CourseId)
        {
            return aCourseManager.GetCourseByCourseId(CourseId);
        }
        public List<CourseAssignToTeacherModel> GetAllCourseAssignedTeachers()
        {
            return aCourseAssignGateway.GetAllCourseAssignedTeachers();
        }
    }
}