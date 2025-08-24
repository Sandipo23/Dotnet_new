using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal interface IStudentReadService
    {
        string FilePath { get; }

        List<Course> GetAllCourses();

        DataTable GetAllHobbies();

        List<StudentRead> GetAll();
    }
}