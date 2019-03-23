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
        public ActionResult ViewAllAssignedTeachers()
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
        public ActionResult AssignTeacher(CourseAssignToTeacherModel courseAssignToTeacherModel)
        {
            ViewBag.Departments = aCourseAssignManager.GetAllDepartments();
            ViewBag.Teachers = aCourseAssignManager.GetAllTeachers();
            ViewBag.CourseCodeList = aCourseAssignManager.GetAllCourseCodes();
            //do the code to store in the database
            if (aCourseAssignManager.IsCourseExist(courseAssignToTeacherModel.CourseId))
            {
                ViewBag.Message = ("Course is already assigned");
            }
            else
            {
                int stored = aCourseAssignManager.SaveCourseAssignToTeacher(courseAssignToTeacherModel);
                if (stored == 1)
                {
                    ViewBag.Message = ("Course Assign to Teacher done successfully");
                }
                else
                {
                    ViewBag.Message = ("Course Assign to Teacher Error");
                }
            }

            return View();

            /* 
             1. one course should be assigned to one teacher only-done
             2. if teacher credit exceed, an dialog box with yes/no pop up and work accordingly
             3. remaining credit returning false count--done
             */
        }



        /// <summary>
        /// to get teacher list from Dept id
        /// </summary>
        /// <param name="deptId"></param>
        /// <returns></returns>
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

        /// <summary>
        /// get teacher credit from teacher table
        /// </summary>
        /// <param name="teacherId"></param>
        /// <returns></returns>
        public JsonResult GetCreditByTeacherId(int teacherId)
        {
            int creditToBeTaken = aCourseAssignManager.GetCreditByTeacherId(teacherId);
            return Json(creditToBeTaken, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// checks how much credits are remaining
        /// </summary>
        /// <param name="teacherId"></param>
        /// <returns>total remaining credit </returns>
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
                remainingCredit = creditToBeTaken - totalAssignedCredit;
            }
            return Json(remainingCredit, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// check if teacherAssignedCredit is more than the credit is being taken
        /// </summary>
        /// <param name="teacherID"></param>
        /// <param name="currentCreditTaking"></param>
        /// <returns></returns>
        public JsonResult CheckTakenCreditOverFlowsRemainingCredit(int teacherID,int currentCreditTaking)
        {
            int creditToBeTaken = aCourseAssignManager.GetCreditByTeacherId(teacherID);
            int totalAssignedCredit = aCourseAssignManager.GetAssignedCreditByTeacherId(teacherID);
            totalAssignedCredit = totalAssignedCredit + currentCreditTaking;
            if (totalAssignedCredit > creditToBeTaken)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        public JsonResult GetCourseModelByCourseId(int courseId)
        {
            CourseModel aCourseModel = new CourseModel();
            aCourseModel = aCourseAssignManager.GetCourseModelByCourseId(courseId);
            return Json(aCourseModel,JsonRequestBehavior.AllowGet);
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