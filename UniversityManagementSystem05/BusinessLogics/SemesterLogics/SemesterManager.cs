using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem05.Models;

namespace UniversityManagementSystem05.BusinessLogics.SemesterLogics
{
    public class SemesterManager
    {
        SemesterGateway aSemesterGateway = new SemesterGateway();

        public List<SemesterModel> GetAllSemesters()
        {
            List<SemesterModel> semesters = new List<SemesterModel>();
            semesters = aSemesterGateway.GetAllSemesters();
            return semesters;
        }

        public SemesterModel GetSemesterById(int semesterId)
        {
            return aSemesterGateway.GetSemesterById(semesterId);
        }
    }
}