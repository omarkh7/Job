using JobSeekers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSeekers.Services
{
    public interface IJobSeekerServices
    {

        public Task<IEnumerable<JobSeeker>> GetJobSeeker();
        public Task<bool> AddJobSeeker(string JobSeekerName , string JobSeekerMajor, int PhoneNumber);

        public Task<IEnumerable<JobSeeker>> SearchJobSeekerID(int ID);

        public Task<bool> UpdateJobSeeker(string NewJobSeekerName, string NewJobSeekerMajor, int NewPhoneNumber, int JobSeekerSID);

  

        public Task<bool> DeleteJobSeeker (int JodSeekerSID);

    }
}
