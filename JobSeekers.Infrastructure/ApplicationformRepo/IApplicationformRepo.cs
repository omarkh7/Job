using JobSeekers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSeekers.Infrastructure.ApplicationformRepo
{
    public interface IApplicationformRepo
    {
        public Task<IEnumerable<Applicationform>> GetAll();
        public Task<bool> AddApplicationform(Applicationform applicationform);

        public Task<bool> DeleteApplicationform(Applicationform applicationform);
    }
}
