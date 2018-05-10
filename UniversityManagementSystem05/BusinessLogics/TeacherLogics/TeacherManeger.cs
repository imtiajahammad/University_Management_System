using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem05.Models;

namespace UniversityManagementSystem05.BusinessLogics.TeacherLogics
{
    public class TeacherManeger
    {
        TeacherGateWay aTeacherGateWay = new TeacherGateWay();
        public string SaveTeacher(TeacherModel aTeacherModel)
        {
            string message = "";
            if (aTeacherGateWay.IsTeacherEmailExist(aTeacherModel.teacherEmail))
            {
                message = "Teacher Email Exists";
            }
            else
            {
                int rowAffected = aTeacherGateWay.SaveTeacher(aTeacherModel);// aDepartmentGateway.SaveDepartment(aDepartmetModel);
                if (rowAffected > 0)
                {
                    message = "Course Saved Successfully";
                }
                else
                {
                    message = "Sorry! Course Save Failed !!";
                }
            }
            return message;
        }

    }
}