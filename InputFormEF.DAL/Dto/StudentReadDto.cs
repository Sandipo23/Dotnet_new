using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputFormEF.DAL.Dto
{
    public class StudentReadDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Agree { get; set; }
        public string Course { get; set; }
        public string DOB { get; set; }
        public string Profile { get; set; }
        public string CreatedDate { get; set; }
    }
}