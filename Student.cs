using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public bool Agree { get; set; }
        public string Course { get; set; }
        public DateTime DOB { get; set; }
        public string Profile { get; set; }
        public string[] Hobbies { get; set; }
        public DateTime CreatedDate { get; set; }

        public Student()
        {
            CreatedDate = DateTime.Now;
        }
    }
}