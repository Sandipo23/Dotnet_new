using InputFormEF.DAL;
using InputFormEF.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputFormEF.DAL
{
    public interface IStudentReadRepository
    {
        Task<List<Course>> GetAllCoursesAsync();

        Task<List<Hobby>> GetAllHobbiesAsync();

        Task<List<Student>> GetAllAsync();

        Task<Student> GetByIdAsync(int id);
    }
}