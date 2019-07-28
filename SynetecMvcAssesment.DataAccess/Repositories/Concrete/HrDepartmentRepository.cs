using InterviewTestTemplatev2.Data;
using SynetecMvcAssesment.DataAccess.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynetecMvcAssesment.DataAccess.Repositories.Concrete
{
    public class HrDepartmentRepository : GenericRepository<HrDepartment>, IHrDepartmentRepository
    {
        private readonly MvcInterviewV3Entities1 _entities;
        public HrDepartmentRepository(MvcInterviewV3Entities1 context) : base (context)
        {
            _entities = context;
        }

        public int? GetDepartmentDetailsById(int departmentId)
        {
            return _entities.HrDepartments.Where(item => item.ID == departmentId).Select(item=>item.BonusPoolAllocationPerc).SingleOrDefault();
        }
    }
}
