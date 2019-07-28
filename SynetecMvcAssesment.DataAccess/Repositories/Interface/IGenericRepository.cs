using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynetecMvcAssesment.DataAccess.Repositories.Interface
{
    public interface IGenericRepository <T> where T : class
    {
        T GetById(int id);
    }
}
