using JobSeekers.Infrastructure.JobSeekerRepo;
using JobSeekers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSeekers.Services
{
    public class JobSeekerServices : IJobSeekerServices
    {
        private readonly IJobSeekerRepo _jobseekerRepo;


        public JobSeekerServices(IJobSeekerRepo rw)
        {

            _jobseekerRepo = rw;
        }


        public async Task<IEnumerable<JobSeeker>> GetJobSeeker()
        {

            var result = await _jobseekerRepo.GetAll();

            return result;
        }


        public async Task<bool> AddJobSeeker(string name, string major, int Phonenumber)
        {
            JobSeeker jobSeeker = new JobSeeker()
            { JobSeekerName = name , JobSeekerMajor=major , PhoneNumber=Phonenumber};
   
            return await _jobseekerRepo.AddJobSeeker(jobSeeker);

        }

        public async Task<IEnumerable<JobSeeker>> SearchJobSeekerID(int ID)
        {
            var jobseekerid = await _jobseekerRepo.SearchJobSeekerID(ID);
            return jobseekerid;
        }

        public async Task<bool> UpdateJobSeeker(string NewJobSeekerName, string NewJobSeekerMajor, int NewPhoneNumber, int JobSeekerSID)
        {
            var jobseekerid = await _jobseekerRepo.SearchJobSeekerID(JobSeekerSID);
            await _jobseekerRepo.UpdateJobSeeker(NewJobSeekerName, NewJobSeekerMajor, NewPhoneNumber, JobSeekerSID);
            return true;

        }


  




        public async Task<bool> DeleteJobSeeker( int JodSeekerSID)
        {
            JobSeeker jobSeeker = new JobSeeker()
            { JobSeekerSID = JodSeekerSID };

            return await _jobseekerRepo.DeleteJobSeeker(jobSeeker);

        }

    }
}
