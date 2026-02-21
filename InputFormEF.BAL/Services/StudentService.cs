using Azure;
using FluentValidation;
using InputFormEF.BAL.Dto;
using InputFormEF.BAL.Interfaces;
using InputFormEF.DAL;

using InputFormEF.DAL.Entities;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace InputFormEF.BAL.Services
{
    public class StudentService : IStudentReadService, IStudentWriteService
    {
        private readonly string path;
        private readonly IStudentReadRepository _studentReadRepository;
        private readonly IStudentWriteRepository _studentWriteRepository;
        private readonly IConfiguration _configuration;
        private readonly IValidator<StudentCreateDto> _studentCreateValidator;

        public StudentService(IStudentReadRepository studentReadRepository, IStudentWriteRepository studentWriteRepository,
            IConfiguration configuration, IValidator<StudentCreateDto> studentCreateValidator)
        {
            // _folderLocation = ConfigurationManager.AppSettings["FolderLocation"];
            _configuration = configuration;

            _studentReadRepository = studentReadRepository;
            _studentWriteRepository = studentWriteRepository;
            _studentCreateValidator = studentCreateValidator;

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

        public async Task<OutputDto> SaveAsync(StudentCreateDto request)
        {
            try
            {
                var validationResult = await _studentCreateValidator.ValidateAsync(request);
                if (!validationResult.IsValid)
                    return OutputDtoConverter.SetFailed(validationResult);

                var student = new Student
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Gender = request.Gender,
                    Agree = request.Agree,
                    CourseId = request.CourseId,
                    DOB = request.DOB.Value,
                    Profile = request.Profile,
                    StudentHobbies = request
                                     .HobbyIds
                                     .Select(x => new StudentHobby
                                     {
                                         HobbyId = x
                                     })
                                     .ToList(),
                };
                await _studentWriteRepository.SaveAsync(student);
                return OutputDtoConverter.SetSuccess(_module, Operation.Save);
            }
            catch (Exception ex)
            {
                return OutputDtoConverter.SetFailed(ex.Message);
            }
        }

        // public async Task SaveAsync(Student student)
        // {
        //     await _studentWriteRepository.SaveAsync(student);
        //  }

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