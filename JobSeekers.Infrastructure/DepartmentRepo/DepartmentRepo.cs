using Dapper;
using JobSeekers.Model;
using students.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSeekers.Infrastructure.DepartmentRepo
{
    public class DepartmentRepo :IDepartmentRepo
    {
        private readonly DapperContext _context;
        public DepartmentRepo(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Department>> GetAll()
        {
            var query = "SELECT * FROM Department";
            using (var connection = _context.CreateConnection())
            {
                var companies = await connection.QueryAsync<Department>(query);
                return companies.ToList();
            }

        }

        public async Task<bool> AddDepartment(Department department)
        {
            var query = "INSERT INTO Department (DepartmentName) VALUES (@Name)";
            var parameters = new DynamicParameters();
            parameters.Add("Name", department.DepartmentName);


            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);


            }
            return true;

        }

    }
}
