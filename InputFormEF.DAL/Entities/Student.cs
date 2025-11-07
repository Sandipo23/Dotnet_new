using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputFormEF.DAL.Entities
{
    internal class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public bool Agree { get; set; }
        public int CourseId { get; set; }
        public DateTime DOB { get; set; }
        public string Profile { get; set; }
        public DateTime CreatedDate { get; set; }
        public Course Course { get; set; }
        public ICollection<StudentHobby> StudentHobbies { get; set; }
    }
}