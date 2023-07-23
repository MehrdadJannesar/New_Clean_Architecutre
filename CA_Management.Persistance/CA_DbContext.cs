using CA.Domain.Common;
using CA.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CA.Persistance
{
    public class CA_DbContext : DbContext
    {
        public CA_DbContext(DbContextOptions<CA_DbContext> options) :
            base(options)
        {

        }
        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CA_DbContext).Assembly);
        }


        // in method zamani ke modefied anjam beshe ya chizi ijad beshe be sorate khodkar lastmodifieddate va datecreate zaman feli ra migirad ke niaz 
        // nist ma har seri an ra code farakhani konim
        // mitavanim az in ravesh braye log ham estefade konim. masalan baraye update mitonim dadehaye ghabl ro jayi zakhire konim.
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>())
            {

                entry.Entity.LastModifiedDate = DateTime.Now;
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>())
            {
                entry.Entity.LastModifiedDate = DateTime.Now;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }
    }
}
