using Dapper;
using JobSeekers.Model;
using students.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSeekers.Infrastructure.ApplicationformRepo
{
    public class ApplicationformRepo : IApplicationformRepo
    {
        private readonly DapperContext _context;
        public ApplicationformRepo(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Applicationform>> GetAll()
        {
            var query = "SELECT * FROM Applicationform";
            using (var connection = _context.CreateConnection())
            {
                var companies = await connection.QueryAsync<Applicationform>(query);
                return companies.ToList();
            }

        }

        public async Task<bool> AddApplicationform(Applicationform applicationform)
        {
            var query = "INSERT INTO Applicationform (FirstName, LastName,Email,PhoneNumber,Addresslocation,DepartmentSID) VALUES (@fname ,@lname,@email,@phonenb,@addresslocation,@departmentsid)";
            var parameters = new DynamicParameters();
            parameters.Add("fname", applicationform.FirstName, DbType.String);
            parameters.Add("lname", applicationform.LastName, DbType.String);
            parameters.Add("email", applicationform.Email, DbType.String);
            parameters.Add("phonenb", applicationform.PhoneNumber, DbType.Int32);
            parameters.Add("addresslocation", applicationform.Addresslocation, DbType.String);
            parameters.Add("departmentsid", applicationform.DepartmentSID, DbType.Int32);


            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);


            }
            return true;

        }


        public async Task<bool> DeleteApplicationform(Applicationform applicationform)
        {
            var query = "DELETE FROM Applicationform WHERE ApplicationformSID =@ID";
            var parameters = new DynamicParameters();

            parameters.Add("ID", applicationform.ApplicationformSID, DbType.Int32);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);


            }
            return true;

        }

    }
}
