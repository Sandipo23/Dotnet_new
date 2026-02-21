using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputFormEF.BAL.Dto
{
    public class StudentCreateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public bool Agree { get; set; }
        public int CourseId { get; set; }
        public DateTime DOB { get; set; }
        public string Profile { get; set; }
        public List<int> HobbyIds { get; set; }

        public StudentCreateDto()
        {
            HobbyIds = new List<int>();
        }
    }
}