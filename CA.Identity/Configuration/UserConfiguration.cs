using CA.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Identity.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            builder.HasData(
                new ApplicationUser
                {
                    Id = "FE276670-A9AA-49A0-85CB-9FF3C5F1E40B",
                    FirstName = "Mehrdad",
                    LastName = "Jannesar",
                    Email = "Jannesar.computer@gmail.com",
                    NormalizedEmail = "JANNESAR.COMPUTER@GMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "admin@sh"),
                    UserName = "MehrdadTk",
                    NormalizedUserName = "MEHRDADTK",
                    EmailConfirmed = true,
                },
                new ApplicationUser
                {
                    Id = "9ACB236C-19B8-46DF-B440-BBC096256F95",
                    FirstName = "System",
                    LastName = "Admin",
                    Email = "Admin@localhost.com",
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    PasswordHash = hasher.HashPassword(null, "admin@shm"),
                    UserName = "UserTk",
                    NormalizedUserName = "USERTK",
                    EmailConfirmed = true,
                }
                );
        }
    }
}
