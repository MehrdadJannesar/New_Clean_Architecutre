using CA.Application.DTOs.DTOs_User.LeaveAllocation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA.Application.Features.LeaveAllocations.Requests.Commands
{
    public class UpdateLeaveAllocationCommand:IRequest<Unit>
    {
        public UpdateLeaveAllocationDTO UpdateLeaveAllocationDTO { get; set; }
    }
}
