using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSeekers.Model
{
    public class Applicationform
    {
        public int ApplicationformSID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string Addresslocation { get; set; }
        public int DepartmentSID { get; set; }

    }
}
