using CA.Application.DTOs.DTOs_User.LeaveType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA.Application.Features.LeaveTypes.Requests.Commands
{
    public class UpdateLeaveTypeCommand:IRequest<Unit> // unit == void == نخواهیم چیزی برگردانیم
    {
        public LeaveTypeDTO LeaveTypeDTO { get; set; }
    }
}
