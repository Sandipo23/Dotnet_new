using InputFormEF.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputFormEF.DAL.Configurations
{
    internal class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder
            .Property(x => x.Name)
           .HasMaxLength(100);

            builder
              .HasData(GetCourses());
        }

        private List<Course> GetCourses()
        {
            var courses = new List<Course>
            {
                 new Course
                 {
                      Id = 1,
                      Name = "BCA"
                 },
                 new Course
                 {
                      Id = 2,
                      Name = "BIT"
                 },
                 new Course
                 {
                      Id = 3,
                      Name = "BIM"
                 },
                 new Course
                 {
                      Id = 4,
                      Name = "BBA"
                 },
                 new Course
                 {
                      Id = 5,
                      Name = "BBS"
                 }
            };
            return courses;
        }
    }
}