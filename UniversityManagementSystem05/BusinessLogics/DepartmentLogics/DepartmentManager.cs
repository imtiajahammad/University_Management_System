using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem05.Models;

namespace UniversityManagementSystem05.BusinessLogics.DepartmentLogics
{
    public class DepartmentManager
    {
        DepartmentGateway aDepartmentGateway = new DepartmentGateway();
        public string SaveDepartment(DepartmentModel aDepartmetModel)
        {
            string message = "";
            if (aDepartmentGateway.IsDepartmentCodeExist(aDepartmetModel.departmentCode))
            {
                message = "Department Code Exists";
            }
            else if (aDepartmentGateway.IsDepartmentNameExist(aDepartmetModel.departmentName))
            {
                message = "Department Name Exists";
            }
            else
            {
                int rowAffected = aDepartmentGateway.SaveDepartment(aDepartmetModel);
                if (rowAffected > 0)
                {
                    message = "Department Saved Successfully";
                }
                else
                {
                    message = "Sorry! Department Save Failed !!";
                }
            }
            return message;
        }

        public List<DepartmentModel> ViewAllDepartments()
        {

            List<DepartmentModel> departments = new List<DepartmentModel>();
            departments = aDepartmentGateway.GetAllDepartment();
            return departments;
        }



        public bool IsDepartmentCodeExist(string DeptCode)
        {
            return aDepartmentGateway.IsDepartmentCodeExist(DeptCode);
        }

        public bool IsDepartmentNameExist(string DeptName)
        {
            return aDepartmentGateway.IsDepartmentNameExist(DeptName);
        }

        public DepartmentModel GetDepartmentForEdit(int DeptId)
        {
            DepartmentModel aDepartmentModel = new DepartmentModel();
            aDepartmentModel = aDepartmentGateway.GetDepartmentForEdit(DeptId);
            return aDepartmentModel;
        }

        public int UpdateDepartment(DepartmentModel aDepartmetModel)
        {
            //            string message = "";
            if (aDepartmentGateway.IsDepartmentCodeExist(aDepartmetModel.departmentCode)){
                return 5;
            }

            else if (aDepartmentGateway.IsDepartmentNameExist(aDepartmetModel.departmentName)){

                return 6;
            }
            else
            {
                int rowAffected = aDepartmentGateway.UpdateDepartment(aDepartmetModel);


                //return message;
                return rowAffected;
            }

            
        }

        public int DeleteDepartment(int departmentId)
        {
  //          string message = "";

            int rowAffected = aDepartmentGateway.DeleteDepartment(departmentId);


            //return message;
            return rowAffected;
        }

    }
}