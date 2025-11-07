using InputForm.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputForm.BAL
{
    public interface IStudentReadService
    {
        string FilePath { get; }

        Task<List<Course>> GetAllCoursesAsync();

        Task<List<Hobby>> GetAllHobbiesAsync();

        Task<List<StudentRead>> GetAllAsync();
    }
}