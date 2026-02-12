using InputFormEF.DAL.Data;
using InputFormEF.DAL.Dto;
using InputFormEF.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace InputFormEF.DAL
{
    public class StudentRepository : IStudentReadRepository, IStudentWriteRepository
    {
        private readonly ApplicationDbContext _context;
        //  private readonly IDapperRepository _dapper;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Course>> GetAllCoursesAsync()
        {
            var courses = await _context
                                .Courses
                                .ToListAsync();
            return courses;
        }

        public async Task<List<Hobby>> GetAllHobbiesAsync()
        {
            var hobbies = await _context
                                .Hobbies
                                .ToListAsync();
            return hobbies;
        }

        public async Task<List<Student>> GetAllAsync()
        {
            var students = await _context
                                 .Students
                                 .Include(x => x.Course)
                                 .ToListAsync();
            return students;
        }

        public async Task SaveAsync(Student student)     //student property ma vayeko information yeta pass hunxa
        {
            await _context
                   .Students
                   .AddAsync(student);
            await _context.SaveChangesAsync();
        }
    }
}