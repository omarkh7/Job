using JobSeekers.Infrastructure.DepartmentRepo;
using JobSeekers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSeekers.Services
{
    public class DepartmentServices : IDepartmentServices
    {

        private readonly IDepartmentRepo _departmentRepo;


        public DepartmentServices(IDepartmentRepo rw)
        {

            _departmentRepo = rw;
        }

        public async Task<IEnumerable<Department>> GetDepartment()
        {

            var result = await _departmentRepo.GetAll();

            return result;
        }
        public async Task<bool> AddDepartment(string DepartmentName)
        {
            Department department = new Department()
            { DepartmentName = DepartmentName };

            return await _departmentRepo.AddDepartment(department);

        }


    }
}
