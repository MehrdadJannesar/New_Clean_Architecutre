using CA.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA.Persistance.Configurations.Entities
{
    public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
    {
        public void Configure(EntityTypeBuilder<LeaveType> builder)
        {
            builder.HasData(
                new LeaveType
                {
                    Id = Guid.NewGuid(),
                    Name = "Vaction",
                    DefaultDay = 10
                },
                new LeaveType
                {
                    Id = Guid.NewGuid(),
                    Name = "Sick",
                    DefaultDay = 12
                }
                ); ;
        }
    }
}
