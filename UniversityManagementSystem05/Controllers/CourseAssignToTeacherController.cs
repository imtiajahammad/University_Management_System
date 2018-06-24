using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem05.BusinessLogics.CourseLogics;
using UniversityManagementSystem05.BusinessLogics.DepartmentLogics;
using UniversityManagementSystem05.BusinessLogics.TeacherLogics;
using UniversityManagementSystem05.Models;

namespace UniversityManagementSystem05.Controllers
{
    public class CourseAssignToTeacherController : Controller
    {
        // GET: CourseAssignToTeacher
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AssignTeacher()
        {
            ViewBag.Departments = GetAllDepartments();
            ViewBag.Teachers = GetAllTeachers();
            ViewBag.CourseCodeList = GetAllCourseCodes();
            return View();
        }
        [HttpPost]
        public ActionResult AssignTeacher(CourseAssignToTeacherModel courseAssignToTeacherModel)
        {
            return View();
        }
        public List<DepartmentModel> GetAllDepartments()
        {
            DepartmentManager aDepartmentManager = new DepartmentManager();
            List<DepartmentModel> list = aDepartmentManager.ViewAllDepartments();
            return list;
        }
        public List<TeacherModel> GetAllTeachers()
        {
            TeacherManager teacherManager = new TeacherManager();
            return teacherManager.GetAllTeachers();
        }
        public List<CourseModel> GetAllCourseCodes()
        {
            CourseManager aCourseManager = new CourseManager();
            return aCourseManager.ViewAllCourses();
        }


        [HttpGet]
        public ActionResult EditAssignedTeacher(int id, int? message)
        {
            return View();
        }
        [HttpPost]
        public ActionResult EditAssignedTeacher(CourseAssignToTeacherModel courseAssignToTeacherModel)
        {
            return View();
        }

        [HttpGet]
        public ActionResult DeleteAssignedTeacher()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeleteAssignedTeacher(int id)
        {
            return View();
        }

    }
}