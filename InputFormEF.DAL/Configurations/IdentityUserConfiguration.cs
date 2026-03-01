using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputFormEF.DAL.Configurations
{
    internal class IdentityUserConfiguration : IEntityTypeConfiguration<IdentityUser<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityUser<int>> builder)
        {
            builder
            .HasData(GetUsers());
        }

        private List<IdentityUser<int>> GetUsers()
        {
            //var passwordHasher = new PasswordHasher<IdentityUser<int>>();
            //string password = passwordHasher.HashPassword(null, "Sandip1@3");
            var users = new List<IdentityUser<int>>
            {
                new IdentityUser<int>
                {
                    Id = 1,
                    ConcurrencyStamp = "fcd534fa-eaac-415e-b48d-81499e8af369",
                    SecurityStamp = "0b466d41-3ed7-4a7d-932a-bd712035db9f",
                    UserName = "sandip",
                    NormalizedUserName = "SANDIP",
                    Email = "sandipbhandari@gmail.com",
                    NormalizedEmail = "SANDIPBHANDARI6699@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEINk4Dtr4TtlQnI6BwpMPp7OiovNVy1P5M19NNVLF77UgPvqyam+AvFax/2cqDpK5Q=="
                }
            };

            return users;
        }
    }
}