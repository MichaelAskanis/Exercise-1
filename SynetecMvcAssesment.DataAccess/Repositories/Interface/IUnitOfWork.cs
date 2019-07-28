using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynetecMvcAssesment.DataAccess.Repositories.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        T Get<T>() where T : class;

        IHrDepartmentRepository hrDepartment { get; }
        IHrEmployeeRepository hrEmployee { get; }
        
    }
}
