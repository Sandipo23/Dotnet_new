using Azure;
using FluentValidation;
using InputFormEF.BAL.ApplicationConstant;
using InputFormEF.BAL.Dto;
using InputFormEF.BAL.Enums;
using InputFormEF.BAL.Interfaces;
using InputFormEF.BAL.Utilities;
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
        private readonly IValidator<StudentUpdateDto> _studentUpdateValidator;
        private readonly IValidator<SaveImageRequest> _saveImageRequestValidator;
        private const string _module = "Student";

        public StudentService(IStudentReadRepository studentReadRepository, IStudentWriteRepository studentWriteRepository,
            IConfiguration configuration, IValidator<StudentCreateDto> studentCreateValidator, IValidator<StudentUpdateDto> studentUpdateValidator
            , IValidator<SaveImageRequest> saveImageRequestValidator)
        {
            // _folderLocation = ConfigurationManager.AppSettings["FolderLocation"];
            _configuration = configuration;

            _studentReadRepository = studentReadRepository;
            _studentWriteRepository = studentWriteRepository;
            _studentCreateValidator = studentCreateValidator;
            _studentUpdateValidator = studentUpdateValidator;
            _saveImageRequestValidator = saveImageRequestValidator;

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

        public async Task<OutputDto<List<StudentReadDto>>> GetAllAsync()
        {
            try
            {
                var result = await _studentReadRepository.GetAllAsync();
                var students = StudentUtility.ConvertToStudentRead(result);
                return OutputDtoConverter.SetSuccess(students);
            }
            catch (Exception ex)
            {
                return OutputDtoConverter.SetFailed(ex.Message, new List<StudentReadDto>());
            }
        }

        public async Task<OutputDto<List<Course>>> GetAllCoursesAsync()
        {
            try
            {
                var courses = await _studentReadRepository.GetAllCoursesAsync();
                return OutputDtoConverter.SetSuccess(courses);
            }
            catch (Exception ex)
            {
                return OutputDtoConverter.SetFailed(ex.Message, new List<Course>());
            }
        }

        public async Task<OutputDto<List<Hobby>>> GetAllHobbiesAsync()
        {
            try
            {
                var hobbies = await _studentReadRepository.GetAllHobbiesAsync();
                return OutputDtoConverter.SetSuccess(hobbies);
            }
            catch (Exception ex)
            {
                return OutputDtoConverter.SetFailed(ex.Message, new List<Hobby>());
            }
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
                return OutputDtoConverter.SetSuccess(_module, ApplicationConstant.Operation.Save);
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

        public async Task<OutputDto> SaveImageAsync(SaveImageRequest request)
        {
            try
            {
                var validationResult = await _saveImageRequestValidator.ValidateAsync(request);
                if (!validationResult.IsValid)
                    return OutputDtoConverter.SetFailed(validationResult);

                if (!String.IsNullOrEmpty(request.Source) && !String.IsNullOrEmpty(request.Destination))
                {
                    File.Copy(request.Source, request.Destination, true);
                }
                return OutputDtoConverter.SetSuccess(_module, ApplicationConstant.Operation.Save);
            }
            catch (Exception ex)
            {
                return OutputDtoConverter.SetFailed(ex.Message);
            }
        }

        public async Task<OutputDto> UpdateAsync(StudentUpdateDto request)
        {
            try
            {
                var validationResult = await _studentUpdateValidator.ValidateAsync(request);
                if (!validationResult.IsValid)
                    return OutputDtoConverter.SetFailed(validationResult);

                var student = new Student
                {
                    Id = request.Id,
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
                await _studentWriteRepository.UpdateAsync(student);
                return OutputDtoConverter.SetSuccess(_module, ApplicationConstant.Operation.Update);
            }
            catch (Exception ex)
            {// if exception is found then we return this code
                return OutputDtoConverter.SetFailed(ex.Message);
            }
        }

        public async Task<OutputDto> DeleteAsync(int studentId)
        {
            try

            {
                if (studentId <= 0)
                    return OutputDtoConverter.SetFailed("Id is required.");
                await _studentWriteRepository.DeleteAsync(studentId);
                return OutputDtoConverter.SetSuccess(_module, ApplicationConstant.Operation.Delete);
            }
            catch (Exception ex)
            {
                return OutputDtoConverter.SetFailed(ex.Message);
            }
        }

        #endregion Write

        public async Task<OutputDto<Student>> GetByIdAsync(int id)
        {
            try
            {
                var student = await _studentReadRepository.GetByIdAsync(id);
                return OutputDtoConverter.SetSuccess(student);
            }
            catch (Exception ex)
            {
                return OutputDtoConverter.SetFailed<Student>(ex.Message, null);
            }
        }
    }
}