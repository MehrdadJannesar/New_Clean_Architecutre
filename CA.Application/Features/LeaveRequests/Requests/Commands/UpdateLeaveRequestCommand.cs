using CA.Application.DTOs.DTOs_User.LeaveRequest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA.Application.Features.LeaveRequests.Requests.Commands
{
    public class UpdateLeaveRequestCommand:IRequest<Unit>
    {
        public Guid Id { get; set; }
        public UpdateLeaveRequestDTO UpdateLeaveRequestDTO { get; set; }
        public ChangeLeaveRequestApprovalDTO ChangeLeaveRequestApprovalDTO { get; set; }
    }
}
