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
    internal class HobbyConfiguration : IEntityTypeConfiguration<Hobby>
    {
        public void Configure(EntityTypeBuilder<Hobby> builder)
        {
            builder
            .Property(x => x.Name)
            .HasMaxLength(100);

            builder
            .HasData(GetHobbies());
        }

        private List<Hobby> GetHobbies()
        {
            var hobbies = new List<Hobby>
            {
                new Hobby
                {
                    Id = 1,
                    Name = "Music"
                },
                new Hobby
                {
                    Id = 2,
                    Name = "Dance"
                },
                new Hobby
                {
                    Id = 3,
                    Name = "Programming"
                },
                new Hobby
                {
                    Id = 4,
                    Name = "Hiking"
                },
                new Hobby
                {
                    Id = 5,
                    Name = "Swimming"
                }
            };
            return hobbies;
        }
    }
}