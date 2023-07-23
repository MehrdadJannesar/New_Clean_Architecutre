using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA.Application.Features.LeaveAllocations.Requests.Commands
{
    public class DeleteLeaveAllocationCommand:IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
