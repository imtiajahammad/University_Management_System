using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem05.Models;

namespace UniversityManagementSystem05.BusinessLogics.DesignationLogics
{
    public class DesignationManager
    {
        
        public List<DesignationModel> GetAllDesignations()
        {
            DesignationGateway aDesignationGateway = new DesignationGateway();
            List<DesignationModel> designations = new List<DesignationModel>();
            designations = aDesignationGateway.GetAllDesignations();
            return designations;
        }
        public DesignationModel GetDesignationById(int designationId)
        {
            DesignationGateway aDesignationGateway = new DesignationGateway();
            DesignationModel aDesignationModel = new DesignationModel();
            aDesignationModel = aDesignationGateway.GetDesignationById(designationId);
            return aDesignationModel;
        }
    }
}