using Dapper;
using InputForm.DAL;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Configuration;
using System.Data;

//using static WinFormsApp1.StudetUtility;

namespace InputForm.DAL
{
    public class StudentRepository : IStudentReadRepository, IStudentWriteRepository
    {
        // Fields
        // private int _id;

        // Constant which is alredy in Constants class
        //public const string _fee = "3,50,000";
        //public const string _format = "dd/MM/yyyy";

        // Readonly
        //  public readonly string _folderLocation;

        private readonly IDapperRepository _dapper;

        public StudentRepository(IDapperRepository dapper)
        {
            // _folderLocation = ConfigurationManager.AppSettings["FolderLocation"];

            // _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            // _dapper = new DapperRepository();
            _dapper = dapper;
        }

        public async Task<List<Course>> GetAllCoursesAsync()
        {
            string query = "SELECT Id, Name FROM Course;";
            var courses = await _dapper.QueryAsync<Course>(query);

            return courses;
        }

        public async Task<List<Hobby>> GetAllHobbiesAsync()
        {
            string query = "SELECT * FROM Hobby;";
            var hobbies = await _dapper.QueryAsync<Hobby>(query);
            return hobbies;
        }

        public async Task SaveAsync(Student student)     //student property ma vayeko information yeta pass hunxa
        {
            // Saves data
            //string json = JsonConvert.SerializeObject(student);
            // string path = $@"{_folderLocation}\student.json";  // this is just a string interpolation

            //var existingStudents = GetExistingStudents();
            //existingStudents.Add(student);
            //string json = JsonConvert.SerializeObject(existingStudents);
            //string path = Path.Combine(FilePath, "student.json");  // used path combine  for cross platform compatibility
            //File.WriteAllText(path, json);

            string query = "[SaveStudent]";
            var parameters = new Dictionary<string, object>();
            parameters.Add("@firstName", student.FirstName);
            parameters.Add("lastName", student.LastName);
            parameters.Add("dob", student.DOB);
            parameters.Add("agree", student.Agree);
            parameters.Add("gender", student.Gender);
            parameters.Add("profile", student.Profile);
            parameters.Add("courseId", student.CourseId);
            parameters.Add("hobbyIds", student.HobbyIds);
            // Named parameter
            int rows = await _dapper.ExecuteAsync(query, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<Student>> GetAllAsync()
        {
            string sp = "GetAllStudents";
            var students = await _dapper.QueryAsync<Student>(sp, commandType: CommandType.StoredProcedure);

            return students;
            //string path = Path.Combine(_folderLocation, "student.json");  //this is to convert the json file to object/data to show in out file
            //if (File.Exists(path))
            //{
            //    string json = File.ReadAllText(path);  //json ko data string ma lauxa
            //    var students = JsonConvert.DeserializeObject<List<Student>>(json);
            //    return students;
            //}

            //return new List<Student>();

            //var studentList = GetExistingStudents();
            //if (studentList.Count > 0)
            //{
            //    var students = StudentUtility.ConvertToStudentRead(studentList);   // yo data grid ma dekhauna ko lagi ho ,data yeta aaunai parxa
            //    return students;
            // }

            // return new List<StudentRead>();
        }

        //  this is for saving into json file
        //private List<Student> GetExistingStudents()
        //{
        //    string path = Path.Combine(FilePath, "student.json");
        //    if (File.Exists(path))
        //    {
        //        string json = File.ReadAllText(path);
        //        var students = JsonConvert.DeserializeObject<List<Student>>(json);   // data stored from saved json file to students variable
        //        return students
        //            .OrderByDescending(x => x.CreatedDate)
        //               .ToList();
        //    }

        //    return new List<Student>();
        //}
    }
}