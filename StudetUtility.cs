using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.DataFormats;

namespace WinFormsApp1
{
    internal static class StudentUtility
    {
        public static List<StudentRead> ConvertToStudentRead(List<Student> students)
        {
            var studentReads = new List<StudentRead>();
            foreach (Student student in students)
            {
                studentReads.Add(new StudentRead
                {
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Gender = student.Gender ? "Male" : "Female",
                    Agree = student.Agree ? "Yes" : "No",
                    Course = student.Course,
                    //  DOB = student.DOB,
                    DOB = student.DOB.ToString(Constants.Format),
                    Profile = Path.GetFileName(student.Profile)
                });
            }

            return studentReads;
        }
    }
}