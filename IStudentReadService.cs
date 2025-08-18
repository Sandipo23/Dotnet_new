using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal interface IStudentReadService
    {
        string FilePath { get; }

        string[] GetAllCourses();

        string[] GetAllHobbies();

        List<StudentRead> GetAll();
    }
}