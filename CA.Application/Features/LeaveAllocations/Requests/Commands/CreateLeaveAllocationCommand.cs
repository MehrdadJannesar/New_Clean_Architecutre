using CA.Application.DTOs.DTOs_User.LeaveAllocation;
using CA.Application.DTOs.DTOs_User.LeaveRequest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA.Application.Features.LeaveAllocations.Requests.Commands
{
    public class CreateLeaveAllocationCommand:IRequest<Guid>
    {
        public CreateLeaveAllocationDTO CreateLeaveAllocationDTO { get; set; }
    }
}
