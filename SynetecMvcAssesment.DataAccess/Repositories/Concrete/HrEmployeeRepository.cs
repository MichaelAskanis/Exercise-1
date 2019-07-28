using InterviewTestTemplatev2.Data;
using SynetecMvcAssesment.DataAccess.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynetecMvcAssesment.DataAccess.Repositories.Concrete
{
    public class HrEmployeeRepository : GenericRepository<HrEmployee>, IHrEmployeeRepository
    {
        private readonly MvcInterviewV3Entities1 _entities;

        public HrEmployeeRepository(MvcInterviewV3Entities1 context) : base(context)
        {
            _entities = context;
        }

        public HrEmployee getEmployeeDetailsById(int employeeId) 
        {
            return _entities.HrEmployees.FirstOrDefault(item => item.ID == employeeId);
        }
    }
}
