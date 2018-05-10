using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem05.Models
{
    public class TeacherModel
    {
        public int teacherId { get; set; }
        public string teacherName { get; set; }
        public string teacherAddress { get; set; }
        public string teacherEmail { get; set; }
        public int teacherNumber { get; set; }
        public string teacherDesignation { get; set; }
        public string teacherDepartment { get; set; }
        public double teacherCreditToBeTacken { get; set; }

    }
}