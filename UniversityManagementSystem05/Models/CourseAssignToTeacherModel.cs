using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem05.Models
{
    public class CourseAssignToTeacherModel
    {
        public int courseAssignToTeacherId { get; set; }
        public string department { get; set; }
        public string teacher { get; set; }
        public int teacherCreditToBeTaken { get; set; }
        public int teacherRemainingCredit { get; set; }
        public string courseCode { get; set; }
        public string courseName { get; set; }
        public int courseCredit { get; set; }
    }
}