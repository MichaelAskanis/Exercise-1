using InterviewTestTemplatev2.Data;
using SynetecMvcAssesment.DataAccess.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynetecMvcAssesment.DataAccess.Repositories.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private MvcInterviewV3Entities1 _context;

        public UnitOfWork(MvcInterviewV3Entities1 context)
        {
            _context = context;
            hrDepartment = new HrDepartmentRepository(_context);
            hrEmployee = new HrEmployeeRepository(_context);
        }

        public IHrDepartmentRepository hrDepartment { get; }
        public IHrEmployeeRepository hrEmployee { get; }

        public T Get<T>() where T: class
        {
            return _context as T;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
