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
    internal class StudentHobbyConfiguration : IEntityTypeConfiguration<StudentHobby>
    {
        public void Configure(EntityTypeBuilder<StudentHobby> builder)
        {
            builder
             .HasKey(x => new
             {
                 x.StudentId,
                 x.HobbyId
             });

            builder
            .HasOne(x => x.Student)
            .WithMany(x => x.StudentHobbies)
            .HasForeignKey(x => x.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

            builder
            .HasOne(x => x.Hobby)
            .WithMany(x => x.StudentHobbies)
            .HasForeignKey(x => x.HobbyId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}