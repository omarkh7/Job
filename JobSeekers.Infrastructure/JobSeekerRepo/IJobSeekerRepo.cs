using JobSeekers.Model;
using students.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSeekers.Infrastructure.JobSeekerRepo
{
    public interface IJobSeekerRepo
    {
        public Task<IEnumerable<JobSeeker>> GetAll();
        public Task<bool> AddJobSeeker(JobSeeker jobSeeker);
        public Task<IEnumerable<JobSeeker>> SearchJobSeekerID(int ID);

        public Task<bool> UpdateJobSeeker(string NewJobSeekerName, string NewJobSeekerMajor , int NewPhoneNumber , int JobSeekerSID);

        
        public Task<bool> DeleteJobSeeker(JobSeeker jobSeeker);



    }
}
