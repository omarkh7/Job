using JobSeekers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSeekers.Services
{
    public interface IApplicationformServices
    {
        public Task<IEnumerable<Applicationform>> GetApplicationForm();


        public Task<bool> AddApplicationform(string FirstName, string LastName,string Email, int PhoneNumber,string Addresslocation ,int DepartmentSID);

        public Task<bool> DeleteApplicationform(int ApplicationformSID);
    }
}
