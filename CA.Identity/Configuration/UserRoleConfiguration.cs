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
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    //Adminstrator
                    UserId = "9ACB236C-19B8-46DF-B440-BBC096256F95",
                    RoleId ="8B835DBD-6801-415B-81B9-299A0048F525"
                },
                new IdentityUserRole<string>
                {
                    //Employee
                    UserId = "FE276670-A9AA-49A0-85CB-9FF3C5F1E40B",
                    RoleId = "91E0419A-2274-4AE6-85A5-844D8B0634CB"
                }
                );
        }
    }
}
