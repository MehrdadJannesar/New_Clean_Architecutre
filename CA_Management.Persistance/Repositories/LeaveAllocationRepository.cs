using CA.Application.Persistance.Contract.Repositories;
using CA.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CA.Persistance.Repositories
{
    public class LeaveAllocationRepository:GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly CA_DbContext _dbContext;

        public LeaveAllocationRepository(CA_DbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationList()
        {
            var leaveAllocations = await _dbContext.LeaveAllocations
                .Include(t => t.LeaveType)
                .ToListAsync();
            return leaveAllocations;
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(Guid Id)
        {
            var leaveAllocation = await _dbContext.LeaveAllocations
                .Include(t => t.LeaveType)
                .FirstOrDefaultAsync(a => a.Id == Id); 
            return leaveAllocation;
        }
    }
}
