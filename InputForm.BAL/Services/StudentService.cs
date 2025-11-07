using InputForm.DAL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputForm.BAL
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

        public async Task<List<StudentRead>> GetAllAsync()
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

        #endregion Write
    }
}