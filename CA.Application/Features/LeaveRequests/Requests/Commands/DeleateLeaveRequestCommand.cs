using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA.Application.Features.LeaveRequests.Requests.Commands
{
    public class DeleateLeaveRequestCommand:IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
