using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.Devices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using static WinFormsApp1.StudetUtility;

namespace WinFormsApp1
{
    internal class StudentService : IStudentReadService, IStudentWriteService
    {
        // Fields
        private int _id;

        // Constant which is alredy in Constants class
        //public const string _fee = "3,50,000";
        //public const string _format = "dd/MM/yyyy";

        // Readonly
        //  public readonly string _folderLocation;

        private readonly string path;
        private readonly string _connectionString;

        public string FilePath
        {
            get
            {
                return ConfigurationManager.AppSettings["FolderLocation"];
            }
        }

        public StudentService()
        {
            // _folderLocation = ConfigurationManager.AppSettings["FolderLocation"];
            path = Path.Combine(FilePath, "student.json");
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public List<Course> GetAllCourses()
        {
            var courses = new List<Course>();
            using (var con = new SqlConnection(_connectionString))
            {
                string query = "SELECT Id, Name FROM Course;";
                using (var cmd = new SqlCommand(query, con))
                {
                    try
                    {
                        con.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (!reader.HasRows)
                                return courses;

                            while (reader.Read())
                            {
                                int id = (int)reader["Id"];
                                string name = reader["Name"].ToString();
                                courses.Add(new Course
                                {
                                    Id = id,
                                    Name = name
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                    finally
                    {
                        con.Close();
                    }
                }

                return courses;
            }
        }

        public DataTable GetAllHobbies()
        {
            var table = new DataTable();
            using (var con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Hobby;";
                using (var adapter = new SqlDataAdapter(query, con))
                {
                    try
                    {
                        adapter.Fill(table);
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }

                return table;
            }
        }

        public void Save(Student student)     //student property ma vayeko information yeta pass hunxa
        {
            // Saves data
            //string json = JsonConvert.SerializeObject(student);
            // string path = $@"{_folderLocation}\student.json";  // this is just a string interpolation

            var existingStudents = GetExistingStudents();
            existingStudents.Add(student);
            string json = JsonConvert.SerializeObject(existingStudents);
            string path = Path.Combine(FilePath, "student.json");  // used path combine  for cross platform compatibility
            File.WriteAllText(path, json);
        }

        public void SaveImage(string source, string destination)   // saves he image to our destination file
        {
            File.Copy(source, destination);
        }

        public List<StudentRead> GetAll()
        {
            var students = new List<StudentRead>();
            using (var con = new SqlConnection(_connectionString))
            {
                string query = @"SELECT s.Id, s.FirstName, s.LastName, s.Gender, s.Agree, s.DOB, s.Profile, s.CreatedDate, c.Name Course
                                 FROM Student s
                                 JOIN Course c ON s.CourseId = c.Id;";
                using (var cmd = new SqlCommand(query, con))
                {
                    try
                    {
                        con.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (!reader.HasRows)
                                return students;

                            while (reader.Read())
                            {
                                int id = (int)reader[nameof(StudentRead.Id)];
                                string firstName = reader[nameof(StudentRead.FirstName)].ToString();
                                string lastName = reader[nameof(StudentRead.LastName)].ToString();
                                bool gender = (bool)reader[nameof(StudentRead.Gender)];
                                bool agree = (bool)reader[nameof(StudentRead.Agree)];
                                string course = reader[nameof(StudentRead.Course)].ToString();
                                DateTime dob = (DateTime)reader[nameof(StudentRead.DOB)];
                                DateTime createdDate = (DateTime)reader[nameof(StudentRead.CreatedDate)];
                                string profile = reader[nameof(StudentRead.Profile)].ToString();
                                students.Add(new StudentRead
                                {
                                    Id = id,
                                    FirstName = firstName,
                                    LastName = lastName,
                                    Gender = gender ? "Male" : "Female",
                                    Agree = agree ? "Yes" : "No",
                                    Course = course,
                                    DOB = dob.FormatDate(),
                                    CreatedDate = createdDate.FormatDate(),
                                    Profile = Path.GetFileNameWithoutExtension(profile)
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                    finally
                    {
                        con.Close();
                    }
                }

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
        }

        private List<Student> GetExistingStudents()
        {
            string path = Path.Combine(FilePath, "student.json");
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                var students = JsonConvert.DeserializeObject<List<Student>>(json);   // data stored from saved json file to students variable
                return students
                    .OrderByDescending(x => x.CreatedDate)
                       .ToList();
            }

            return new List<Student>();
        }
    }
}