using CA.Application.DTOs.DTOs_User.LeaveType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA.Application.Features.LeaveTypes.Requests.Commands
{
    public class CreateLeaveTypeCommand:IRequest<Guid>
    {
        public CreateLeaveTypeDTO CreateLeaveTypeDTO { get; set; }
    }
}
