using InputFormEF.BAL.Interfaces;
using InputFormEF.DAL.Entities;
using InputFormEF.DAL.Dto;
using Microsoft.Extensions.Configuration;
using InputFormEF.DAL;

namespace InputFormEF.BAL.Services
{
    public class StudentService : IStudentReadService, IStudentWriteService
    {
        private readonly string path;
        private readonly IStudentReadRepository _studentReadRepository;
        private readonly IStudentWriteRepository _studentWriteRepository;
        private readonly IConfiguration _configuration;

        public StudentService(IStudentReadRepository studentReadRepository, IStudentWriteRepository studentWriteRepository, IConfiguration configuration)
        {
            // _folderLocation = ConfigurationManager.AppSettings["FolderLocation"];
            _configuration = configuration;

            _studentReadRepository = studentReadRepository;
            _studentWriteRepository = studentWriteRepository;
            path = Path.Combine(FilePath, "student.json");
        }

        #region Read

        public string FilePath
        {
            get
            {
                return _configuration["FolderLocation"];
            }
        }

        public async Task<List<StudentReadDto>> GetAllAsync()
        {
            var result = await _studentReadRepository.GetAllAsync();
            var students = StudentUtility.ConvertToStudentRead(result);
            return students;
        }

        public async Task<List<Course>> GetAllCoursesAsync()
        {
            var courses = await _studentReadRepository.GetAllCoursesAsync();
            return courses;
        }

        public async Task<List<Hobby>> GetAllHobbiesAsync()
        {
            var hobbies = await _studentReadRepository.GetAllHobbiesAsync();
            return hobbies;
        }

        #endregion Read

        #region Write

        public async Task SaveAsync(Student student)
        {
            await _studentWriteRepository.SaveAsync(student);
        }

        public void SaveImage(string source, string destination)
        {
            File.Copy(source, destination, true);
        }

        public async Task UpdateAsync(Student student)
        {
            await _studentWriteRepository.UpdateAsync(student);
        }

        public async Task DeleteAsync(int studentId)
        {
            await _studentWriteRepository.DeleteAsync(studentId);
        }

        #endregion Write

        public async Task<Student> GetByIdAsync(int id)
        {
            var student = await _studentReadRepository.GetByIdAsync(id);
            return student;
        }
    }
}