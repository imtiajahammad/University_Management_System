﻿using System;
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
        //public string courseDescription
        //{
        //    get
        //    {
        //        return string.IsNullOrEmpty(this.courseDescription) ? "No Name" :  this.courseDescription;
        //    }
        //    set
        //    {
        //        this.courseDescription = value;
        //    }
        //}
        public string courseDescription { get; set; }
        public int departmentId { get; set; }
        public string department{ get; set; }
        public int semesterId { get; set; }
        public string semester { get; set; }
    }
}