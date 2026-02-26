using InputFormEF.DAL.Entities;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InputFormEF.BAL.Dto;

namespace InputFormEF.BAL.Interfaces
{
    public interface IStudentReadService
    {
        string FilePath { get; }

        Task<OutputDto<List<Course>>> GetAllCoursesAsync();

        Task<OutputDto<List<Hobby>>> GetAllHobbiesAsync();

        Task<OutputDto<List<StudentReadDto>>> GetAllAsync();

        Task<OutputDto<Student>> GetByIdAsync(int id);
    }
}