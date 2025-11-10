using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputFormEF.DAL.Entities
{
    public class StudentHobby
    {
        public int StudentId { get; set; }
        public int HobbyId { get; set; }
        public Student Student { get; set; }
        public Hobby Hobby { get; set; }
    }
}