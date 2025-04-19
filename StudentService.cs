using System;
using System.Collections.Generic;
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
        public readonly string _folderLocation = @"D:\Project_Dotnet";

        public StudentService()
        {
            _folderLocation = "";
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

        public void Save(Student student)
        {
            // Saves data
        }
    }
}