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

            string[] designationArray = { "Professor","Assistance Professor","Senior Teacher","Junior Teacher"};
            List<string> designations= designationArray.ToList();
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

            string[] designationArray = { "Professor", "Assistance Professor", "Senior Teacher", "Junior Teacher" };
            List<string> designations = designationArray.ToList();
            ViewBag.designations = designations;
            return View();
        }
    }
}