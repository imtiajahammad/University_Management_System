using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem05.Models
{
    public class CourseAssignToTeacherModel
    {
        public int courseAssignToTeacherId { get; set; }

        public int departmentId { get; set; }
        public DepartmentModel department { get; set; }
        public int teacherId { get; set; }
        public TeacherModel teacher { get; set; }
        public int teacherCreditToBeTaken { get; set; }
        public int teacherRemainingCredit { get; set; }
        public string courseCode { get; set; }
        public string courseName { get; set; }
        public int courseCredit { get; set; }
    }
}