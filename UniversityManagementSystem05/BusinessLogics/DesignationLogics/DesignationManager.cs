using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem05.Models;

namespace UniversityManagementSystem05.BusinessLogics.DesignationLogics
{
    public class DesignationManager
    {
        DesignationGateway aDesignationGateway= new DesignationGateway();
        public List<DesignationModel> GetAllDesignations()
        {
            List<DesignationModel> designations = new List<DesignationModel>();
            designations = aDesignationGateway.GetAllDesignations();
            return designations;
        }
        public DesignationModel GetDesignationById(int designationId)
        {
            DesignationModel aDesignationModel = new DesignationModel();
            aDesignationModel = aDesignationGateway.GetDesignationById(designationId);
            return aDesignationModel;
        }
    }
}