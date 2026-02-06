using InputFormEF.DAL.Entities;
using InputFormEF.DAL.Dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputFormEF.BAL.Interfaces
{
    public interface IStudentReadService
    {
        string FilePath { get; }

        Task<List<Course>> GetAllCoursesAsync();

        Task<List<Hobby>> GetAllHobbiesAsync();

        Task<List<StudentReadDto>> GetAllAsync();
    }
}