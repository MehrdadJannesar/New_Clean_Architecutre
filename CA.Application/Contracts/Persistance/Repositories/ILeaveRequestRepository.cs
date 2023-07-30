using CA.Application.Contracts.Persistance;
using CA.Application.Contracts.Persistance.CommonRepository;
using CA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CA.Application.Contracts.Persistance.Repositories
{
    public interface ILeaveRequestRepository:IGenericRepository<LeaveRequest>
    {
        Task ChangeApprovalStatus(LeaveRequest leaveReqeust, bool? approvalStatus);
        Task<List<LeaveRequest>> GetLeaveRequestsWithDetails();
        Task<LeaveRequest> GetLeaveRequestWithDetails(Guid id);
    }
}
