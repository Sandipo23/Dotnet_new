using InputFormEF.DAL.Data;

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

        public async Task<Student> GetByIdAsync(int id)
        {
            var student = await _context
                                .Students
                                .Include(x => x.Course)
                                .Include(x => x.StudentHobbies)
                                .FirstOrDefaultAsync(x => x.Id == id);
            return student;
        }

        public async Task SaveAsync(Student student)     //student property ma vayeko information yeta pass hunxa
        {
            await _context
                   .Students
                   .AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Student student)
        {
            var existingStudent = await _context
                                        .Students
                                        .Include(x => x.StudentHobbies)
                                        .FirstOrDefaultAsync(x => x.Id == student.Id);
            if (existingStudent == null)
            {
                throw new NullReferenceException($"Invalid student id {student.Id}");
            }
            existingStudent.FirstName = student.FirstName;
            existingStudent.LastName = student.LastName;
            existingStudent.Gender = student.Gender;
            existingStudent.Agree = student.Agree;
            existingStudent.DOB = student.DOB;
            existingStudent.CourseId = student.CourseId;
            existingStudent.Profile = student.Profile;
            existingStudent.StudentHobbies.Clear();
            existingStudent.StudentHobbies.AddRange(student.StudentHobbies);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int studentId)
        {
            var existingStudent = await _context
                                        .Students
                                        .FirstOrDefaultAsync(x => x.Id == studentId);
            if (existingStudent != null)
            {
                _context
                .Students
                .Remove(existingStudent);
                await _context.SaveChangesAsync();
            }
        }
    }
}