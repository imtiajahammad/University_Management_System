using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem05.BusinessLogics.CourseLogics;
using UniversityManagementSystem05.Models;

namespace UniversityManagementSystem05.Controllers
{
    public class CourseController : Controller
    {
        
        CourseManager aCourseManager = new CourseManager();

        // GET: Course
        [HttpGet]
        public ActionResult SaveCourse()
        {
            List<string> departmentCodeList = aCourseManager.GetDepartmentCodeList();
            string[] courseArray = { "1st Semester", "2nd Semester", "3rd Semester", "4th Semester", "5th Semester", "6th Semester", "7th Semester", "8th Semester" };
            List<string> semesterList = new List<string>();
            //string[] array ={"1st Semester", "2nd Semester", "3rd Semester", "4th Semester", "5th Semester", "6th Semester", "7th Semester", "8th Semester"};
            semesterList = courseArray.ToList();
            ViewBag.departmentCodeList = departmentCodeList;
            ViewBag.semesterList = semesterList;
            return View();
        }

        [HttpPost]
        public ActionResult SaveCourse(CourseModel aCourseModel)
        {
            string message = "";

            message = aCourseManager.SaveCourse(aCourseModel);

            ViewBag.Message = message;

            return View();
        }
    }
}