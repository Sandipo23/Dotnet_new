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
    internal class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder
            .Property(x => x.FirstName)
            .HasMaxLength(100);

            builder
           .Property(x => x.LastName)
           .HasMaxLength(100);

            builder
            .Property(x => x.Profile)
            .HasMaxLength(300);

            builder
            .Property(x => x.CreatedDate)
            .HasDefaultValueSql("GETDATE()");

            builder
            .HasOne(x => x.Course)
            .WithMany(x => x.Students)
            .HasForeignKey(x => x.CourseId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}