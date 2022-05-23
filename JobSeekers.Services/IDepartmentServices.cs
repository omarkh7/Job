using JobSeekers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSeekers.Services
{
   public interface IDepartmentServices
    {
        public Task<IEnumerable<Department>> GetDepartment();

        public Task<bool> AddDepartment(string DepartmentName);




    }
}
