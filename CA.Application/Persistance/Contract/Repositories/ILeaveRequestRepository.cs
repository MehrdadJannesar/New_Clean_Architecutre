using CA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CA.Application.Persistance.Contract.Repositories
{
    public interface ILeaveRequestRepository:IGenericRepository<LeaveRequest>
    {
        Task ChangeApprovalStatus(LeaveRequest leaveReqeust, bool? approvalStatus);
        Task<List<LeaveRequest>> GetLeaveRequestsWithDetails();
        Task<LeaveRequest> GetLeaveRequestWithDetails(Guid id);
    }
}
