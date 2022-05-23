using JobSeekers.Infrastructure.ApplicationformRepo;
using JobSeekers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSeekers.Services
{
    public class ApplicationformServices : IApplicationformServices
    {


        private readonly IApplicationformRepo _applicationformRepo;


        public ApplicationformServices(IApplicationformRepo rw)
        {

            _applicationformRepo = rw;
        }

        public async Task<IEnumerable<Applicationform>> GetApplicationForm()
        {

            var result = await _applicationformRepo.GetAll();

            return result;
        }
        public async Task<bool> AddApplicationform(string fname, string lname, string email, int phonenb, string addresslocation, int departmentsid)
        {
            Applicationform applicationform = new Applicationform()
            { FirstName = fname, LastName = lname, Email = email,PhoneNumber=phonenb,Addresslocation=addresslocation,DepartmentSID=departmentsid };

            return await _applicationformRepo.AddApplicationform(applicationform);

        }

        public async Task<bool> DeleteApplicationform(int ApplicationformSID)
        {
            Applicationform applicationform = new Applicationform()
            { ApplicationformSID = ApplicationformSID };

            return await _applicationformRepo.DeleteApplicationform(applicationform);

        }

    }
}
