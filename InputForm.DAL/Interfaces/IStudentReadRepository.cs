using InputForm.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputForm.DAL
{
    public interface IStudentReadRepository
    {
        Task<List<Course>> GetAllCoursesAsync();

        Task<List<Hobby>> GetAllHobbiesAsync();

        Task<List<Student>> GetAllAsync();
    }
}