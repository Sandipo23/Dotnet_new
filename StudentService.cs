﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class StudentService
    {
        // Fields
        private int _id;

        // Constant
        public const string _fee = "3,50,000";

        // Readonly
        public readonly string _folderLocation;

        private readonly string path;

        public StudentService()
        {
            _folderLocation = ConfigurationManager.AppSettings["FolderLocation"];
            path = Path.Combine(_folderLocation, "student.json");
        }

        public string[] GetAllCourses()
        {
            // 1st syntax
            //string[] courses = new string[6];
            //courses[0] = "Please select a course";
            //courses[1] = "BCA";
            //courses[2] = "BIT";
            //courses[3] = "BIM";
            //courses[4] = "BBA";
            //courses[5] = "BBS";

            // 2nd syntax
            //string[] courses = new string[6] { "Please select a course", "BCA", "BIT", "BIM", "BBA", "BBS" };

            // 3rd syntax
            //string[] courses = new string[] { "Please select a course", "BCA", "BIT", "BIM", "BBA", "BBS" };

            // 4th syntax
            string[] abc = { "Please select a course", "BCA", "BIT", "BIM", "BBA", "BBS" };
            return abc;
        }

        public void Save(Student student)     //student property ma vayeko information yeta pass hunxa
        {
            // Saves data
            //string json = JsonConvert.SerializeObject(student);
            // string path = $@"{_folderLocation}\student.json";  // this is just a string interpolation

            var existingStudents = GetExistingStudents();
            existingStudents.Add(student);
            string json = JsonConvert.SerializeObject(existingStudents);
            string path = Path.Combine(_folderLocation, "student.json");  // used path combine  for cross platform compatibility
            File.WriteAllText(path, json);
        }

        public void SaveImage(string source, string destination)   // saves he image to our destination file
        {
            File.Copy(source, destination);
        }

        public List<StudentRead> GetAll()
        {
            //string path = Path.Combine(_folderLocation, "student.json");  //this is to convert the json file to object/data to show in out file
            //if (File.Exists(path))
            //{
            //    string json = File.ReadAllText(path);  //json ko data string ma lauxa
            //    var students = JsonConvert.DeserializeObject<List<Student>>(json);
            //    return students;
            //}

            //return new List<Student>();

            var studentList = GetExistingStudents();
            if (studentList.Count > 0)
            {
                var students = ConvertToStudentRead(studentList);
                return students;
            }

            return new List<StudentRead>();
        }

        private List<Student> GetExistingStudents()
        {
            string path = Path.Combine(_folderLocation, "student.json");
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                var students = JsonConvert.DeserializeObject<List<Student>>(json);   // data stored from saved json file to students variable
                return students;
            }

            return new List<Student>();
        }

        private List<StudentRead> ConvertToStudentRead(List<Student> students)  // in this method we show gender true false to male female
        {
            var studentReads = new List<StudentRead>();  // existing list (Student) lai new list (StudentRead) ma convert gareko
            foreach (Student student in students)
            {
                studentReads.Add(new StudentRead
                {
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Gender = student.Gender ? "Male" : "Female",
                    Agree = student.Agree ? "Yes" : "No",
                    Course = student.Course,
                    Profile = student.Profile
                });
            }

            return studentReads;
        }
    }
}