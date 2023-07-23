using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA.Application.Features.LeaveTypes.Requests.Commands
{
    public class DeleteLeaveTypeCommand:IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
