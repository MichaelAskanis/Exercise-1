using InterviewTestTemplatev2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynetecMvcAssesment.DataAccess.Repositories.Interface
{
    public interface IHrDepartmentRepository : IGenericRepository<HrDepartment>
    {
        int? GetDepartmentDetailsById(int departmentId);
    }
}
