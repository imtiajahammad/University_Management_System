using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem05.BusinessLogics.CourseAssignLogics;
using UniversityManagementSystem05.BusinessLogics.CourseLogics;
using UniversityManagementSystem05.BusinessLogics.DepartmentLogics;
using UniversityManagementSystem05.BusinessLogics.TeacherLogics;
using UniversityManagementSystem05.Models;

namespace UniversityManagementSystem05.Controllers
{
    public class CourseAssignToTeacherController : Controller
    {
        CourseAssignManager aCourseAssignManager = new CourseAssignManager();
        

        // GET: CourseAssignToTeacher
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AssignTeacher()
        {
            ViewBag.Departments = aCourseAssignManager.GetAllDepartments();
            ViewBag.Teachers = aCourseAssignManager.GetAllTeachers();
            ViewBag.CourseCodeList = aCourseAssignManager.GetAllCourseCodes();
            return View();
        }

        [HttpPost]
        public JsonResult GetTeacherByDeptId(int deptId)
        {
            List<string> teachers = new List<string>();
            //teachers = aCourseAssignManager.GetTeachersByDepartment(dept);
            //var teachers = db.Teachers.Where(m => m.DepartmentId == deptId).ToList();
            //return Json(teachers, JsonRequestBehavior.AllowGet);
            return Json(teachers, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCourseCodeByDept(string dept)
        {
            DepartmentManager aDepartmentManager = new DepartmentManager();
            string deptCode = aDepartmentManager.GetDepartmentCodeByDeptName(dept);

            List<string> course= new List<string>();
            CourseManager aCourseManager = new CourseManager();
            course = aCourseManager.GetCourseNameCreditByDept(dept);
            //var teachers = db.Teachers.Where(m => m.DepartmentId == deptId).ToList();
            //return Json(teachers, JsonRequestBehavior.AllowGet);
            return Json(course, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        //public JsonResult GetCreditByTeacherName(string teacherName)
        //{
        //    int creditToBeTaken = aTeacherManager.GetCreditByTeacherName(teacherName);
        //    return Json(creditToBeTaken,JsonRequestBehavior.AllowGet);
        //}

        //public JsonResult getAssignedCreditByTeacherName(string teacherName)
        //{
        //    int assignCredit= aTeacherManager.getAssignedCreditByTeacherName(teacherName);
        //    return Json(assignCredit, JsonRequestBehavior.AllowGet);
        //}

        //[HttpPost]
        //public JsonResult GetRemainingCreditByTeacherName(string teacherName)
        //{
        //    return Json(null);
        //}
        [HttpPost]
        public JsonResult GetNameCreditByCourseCode(string courseCode)
        {
            return Json(null);
        }

        [HttpPost]
        public ActionResult AssignTeacher(CourseAssignToTeacherModel courseAssignToTeacherModel)
        {
            return View();
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