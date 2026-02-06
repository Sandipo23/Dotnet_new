using InputFormEF.DAL.Dto;
using InputFormEF.DAL.Entities;

namespace InputFormEF.BAL
{
    public static class StudentUtility
    {
        public static List<StudentReadDto> ConvertToStudentRead(List<Student> students)
        {
            //var studentReads = new List<StudentReadDto>();
            //foreach (Student student in students)
            //{
            //    studentReads.Add(new StudentReadDto
            //    {
            //        Id = student.Id,
            //        FirstName = student.FirstName,
            //        LastName = student.LastName,
            //        Gender = student.Gender ? "Male" : "Female",
            //        Agree = student.Agree ? "Yes" : "No",
            //        Course = student.Course.Name,
            //        //  DOB = student.DOB,
            //        // DOB = student.DOB.ToString(Constants.Format), // this is old method without use of extention method
            //        DOB = student.DOB.FormatDate(),             //this is new methof with using extention method
            //        Profile = Path.GetFileName(student.Profile),
            //        CreatedDate = student.CreatedDate.GetDateTimeFormats().First()
            //    });
            //}

            //return studentReads;

            // using linq code

            var studentReads = students
                               .Select(student => new StudentReadDto
                               {
                                   Id = student.Id,
                                   FirstName = student.FirstName,
                                   LastName = student.LastName,
                                   Gender = student.Gender ? "Male" : "Female",
                                   Agree = student.Agree ? "Yes" : "No",
                                   Course = student.Course.Name,
                                   DOB = student.DOB.FormatDate(),
                                   Profile = Path.GetFileName(student.Profile),
                                   CreatedDate = student.CreatedDate.FormatDate()
                               })
                               .ToList();
            return studentReads;
        }
    }
}