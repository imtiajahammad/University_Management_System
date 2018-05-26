using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem05.BusinessLogics.DepartmentLogics;
using UniversityManagementSystem05.BusinessLogics.TeacherLogics;
using UniversityManagementSystem05.Models;

namespace UniversityManagementSystem05.Controllers
{
    public class TeacherController : Controller
    {
        TeacherManeger aTeacherManager = new TeacherManeger();
        // GET: TeacherModel
        [HttpGet]
        public ActionResult SaveTeacher()
        {
            DepartmentManager aDepartmentManager = new DepartmentManager();
            List<DepartmentModel> departmentList = aDepartmentManager.ViewAllDepartments();
            ViewBag.departments = departmentList;

            //string[] designationArray = { "Professor","Assistance Professor","Senior Teacher","Junior Teacher"};
            List<string> designations = aTeacherManager.GetAllDesignations();
            

            ViewBag.designations = designations;
            return View();
        }
        [HttpPost]
        public ActionResult SaveTeacher(TeacherModel aTeacherModel)
        {
            string message = "";

            message = aTeacherManager.SaveTeacher(aTeacherModel);

            ViewBag.Message = message;


            DepartmentManager aDepartmentManager = new DepartmentManager();
            List<DepartmentModel> departmentList = aDepartmentManager.ViewAllDepartments();
            ViewBag.departments = departmentList;

            List<string> designations = aTeacherManager.GetAllDesignations();
            ViewBag.designations = designations;

            return View();
        }

        [HttpGet]
        public ActionResult ViewAllTeachers(int? messageFromEdit)
        {
            List<TeacherModel> teachers = new List<TeacherModel>();
            teachers = aTeacherManager.GetAllTeachers();
            if (teachers.Count == 0)
            {
                string message = "No data in the database for teachers";
                ViewBag.MessageViewCourses = message;
            }
            else if (messageFromEdit > 0)
            {
                ViewBag.MessageViewCourses = "Teacher Updated Successfully";
            }
            ViewBag.CourseList = teachers;
            return View();
        }


        [HttpGet]
        public ActionResult EditTeacherFromList(int teacherId, int? message)
        {
            if (message != null)
            {
                if (message == 0)
                {
                    ViewBag.Message = "Sorry! Teacher Update Failed !!";
                }
                else if (message == 5)
                {
                    ViewBag.Message = "Sorry! Teacher Email Exists !!";  

                }
            }
            TeacherModel aTeacherModel = new TeacherModel();
            aTeacherModel = aTeacherManager.GetTeacherForEdit(teacherId);
            return View(aTeacherModel);
        }


        [HttpPost]
        public ActionResult EditTeacherFromList(TeacherModel aTeacherModel)
        {
            //string message = "";
            int rowAffected;
            rowAffected = aTeacherManager.UpdateTeacher(aTeacherModel);

            //ViewBag.Message2 = message;
            if (rowAffected == 1)
            {
                return RedirectToAction("ViewAllTeachers", new { message = rowAffected });
            }
            else
            {
                return RedirectToAction("EditTeacherFromList", new { teacherId = aTeacherModel.teacherId, message = rowAffected });
            }
        }
        public ActionResult DeleteTeacherFromList(int teacherId)
        {

            int rowsEffected = aTeacherManager.DeleteTeacher(teacherId);
            if (rowsEffected > 0)
            {
                return RedirectToAction("ViewAllTeachers");
            }
            else
            {
                return null;
            }

        }



    }
}