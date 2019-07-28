using InterviewTestTemplatev2.Data;
using SynetecMvcAssesment.DataAccess.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynetecMvcAssesment.Business.Tasks
{
    public class BonusPool
    {
        private MvcInterviewV3Entities1 _dbContext;

        public BonusPool(MvcInterviewV3Entities1 context)
        {
            _dbContext = context;
        }

        public decimal CalculateByEmployeeId(int selectedEmployeeId, decimal bonusAmount)
        {           
            HrEmployee employeeDetails;
            int? bonusPoolAllocationPerc;
            
            try
            {
                using (var unitOfWork = new UnitOfWork(_dbContext)) 
                {
                    employeeDetails = unitOfWork.hrEmployee.getEmployeeDetailsById(selectedEmployeeId);
                    bonusPoolAllocationPerc = unitOfWork.hrDepartment.GetDepartmentDetailsById(employeeDetails.HrDepartmentId);
                }
                return bonusAmount*((decimal)bonusPoolAllocationPerc/100);
            }
            catch (Exception e)
            {
               throw e;
            }          

        }
    }
}


//UnitOfWork _unitOfWork = new UnitOfWork(new MvcInterviewV3Entities1());