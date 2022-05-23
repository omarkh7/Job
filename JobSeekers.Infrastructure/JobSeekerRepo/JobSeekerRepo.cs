using Dapper;
using JobSeekers.Model;
using students.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSeekers.Infrastructure.JobSeekerRepo
{
    public class JobSeekerRepo : IJobSeekerRepo
    {

        private readonly DapperContext _context;
        public JobSeekerRepo(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<JobSeeker>> GetAll()
        {
            var query = "SELECT * FROM JobSeeker";
            using (var connection = _context.CreateConnection())
            {
                var companies = await connection.QueryAsync<JobSeeker>(query);
                return companies.ToList();
            }

        }
        public async Task<bool> AddJobSeeker(JobSeeker jobSeeker)
        {
            var query = "INSERT INTO JobSeeker (JobSeekerName, JobSeekerMajor,Phonenumber) VALUES (@Name ,@Major,@PhoneNumber)";
            var parameters = new DynamicParameters();
            parameters.Add("Name", jobSeeker.JobSeekerName, DbType.String);
            parameters.Add("Major", jobSeeker.JobSeekerMajor, DbType.String);
            parameters.Add("PhoneNumber", jobSeeker.PhoneNumber, DbType.Int32);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);


            }
            return true;

        }

        public async Task<IEnumerable<JobSeeker>> SearchJobSeekerID(int ID)
        {
            var query = "select * from JobSeeker where JobSeekerSID=@ID";

            var parameters = new DynamicParameters();
            parameters.Add("ID", ID, DbType.Int32);

            using (var connection = _context.CreateConnection())
            {
                var jobSeekers = await connection.QueryAsync<JobSeeker>(query, parameters);

                return jobSeekers;
            }
        }

        public async Task<bool> UpdateJobSeeker(string NewJobSeekerName, string NewJobSeekerMajor, int NewPhoneNumber, int JobSeekerSID)
        {
            var query = " UPDATE JobSeeker SET JobSeekerName =@Name , JobSeekerMajor=@Major ,PhoneNumber=@PhoneNumber   WHERE JobSeekerSID =@ID";

            var parameters = new DynamicParameters();
            parameters.Add("Name", NewJobSeekerName, DbType.String);
            parameters.Add("Major", NewJobSeekerMajor, DbType.String);
            parameters.Add("PhoneNumber", NewPhoneNumber, DbType.Int32);
            parameters.Add("ID", JobSeekerSID, DbType.Int32);

            using (var connection = _context.CreateConnection())
                {
                    var jobseeker = await connection.QueryAsync<JobSeeker>(query, parameters);

                    return true;
                }
                return false;

            }


   




        public async Task<bool> DeleteJobSeeker(JobSeeker jobSeeker)
        {
            var query = "DELETE FROM JobSeeker WHERE JobSeekerSID =@ID";
            var parameters = new DynamicParameters();

            parameters.Add("ID", jobSeeker.JobSeekerSID, DbType.Int32);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);


            }
            return true;

        }



    }



    }

    

