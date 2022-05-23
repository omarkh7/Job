using JobSeekers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSeekers.Infrastructure.DepartmentRepo
{
    public interface IDepartmentRepo
    {
        public Task<IEnumerable<Department>> GetAll();
        public Task<bool> AddDepartment(Department department);
    }
}
