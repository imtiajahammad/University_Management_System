using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem05.Models
{
    public class CourseModel
    {
        public int courseId { get; set; }
        public string courseCode { get; set; }
        public string courseName { get; set; }
        public double courseCredit { get; set; }
        public string courseDescription{ get; set; }
        public string courseDepartment { get; set; }
        public string courseSemester { get; set; }
    }
}