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
            List<TeacherModel> teachers = new List<TeacherModel>();
            teachers = aCourseAssignManager.GetTeachersByDeptId(deptId);
            //var teachers = db.Teachers.Where(m => m.DepartmentId == deptId).ToList();
            //return Json(teachers, JsonRequestBehavior.AllowGet);
            return Json(teachers, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCourseListByDeptId(int deptId)
        {
            List<CourseModel> courseList= new List<CourseModel>();
            CourseAssignManager aCourseAssignManager = new CourseAssignManager();
            courseList = aCourseAssignManager.GetCourseListByDeptId(deptId);
            return Json(courseList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetCreditByTeacherId(int teacherId)
        {
            int creditToBeTaken = aCourseAssignManager.GetCreditByTeacherId(teacherId);
            return Json(creditToBeTaken, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetRemainingCreditByTeacherId(int teacherId)
        {
            int creditToBeTaken= aCourseAssignManager.GetCreditByTeacherId(teacherId);
            int remainingCredit;
            int totalAssignedCredit = aCourseAssignManager.GetAssignedCreditByTeacherId(teacherId);
            if (totalAssignedCredit == 0)
            {
                remainingCredit = creditToBeTaken;
            }
            else if (totalAssignedCredit < creditToBeTaken)
            {
                remainingCredit = creditToBeTaken - totalAssignedCredit;
            }
            else
            {
                remainingCredit = 0;
            }
            return Json(remainingCredit, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult GetCourseModelByCourseId(int courseId)
        {
            CourseModel aCourseModel = new CourseModel();
            aCourseModel = aCourseAssignManager.GetCourseModelByCourseId(courseId);
            return Json(aCourseModel,JsonRequestBehavior.AllowGet);
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