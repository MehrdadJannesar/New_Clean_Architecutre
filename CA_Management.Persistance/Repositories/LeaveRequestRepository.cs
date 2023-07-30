using CA.Application.Contracts.Persistance.Repositories;
using CA.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CA.Persistance.Repositories
{
    public class LeaveRequestRepository:GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly CA_DbContext _dbContext;

        public LeaveRequestRepository(CA_DbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task ChangeApprovalStatus(LeaveRequest leaveReqeust, bool? approvalStatus)
        {
            leaveReqeust.Approved = approvalStatus;
            _dbContext.Entry(leaveReqeust).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails()
        {
            var leaveRequests = await _dbContext.LeaveRequests
                .Include(t => t.LeaveType)
                .ToListAsync();
            return leaveRequests;
        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetails(Guid id)
        {
            var leaveRequest = await _dbContext.LeaveRequests
                .Include(t => t.LeaveType)
                .FirstOrDefaultAsync(l=>l.Id == id);
            return leaveRequest;
        }
    }
}
