using CA.Application.DTOs.DTOs_User;
using CA.Application.DTOs.DTOs_User.LeaveType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA.Application.Features.LeaveTypes.Requests.Queries
{
    public class GetLeaveTypeDTODetailsRequest : IRequest<LeaveTypeDTO>
    {
        public Guid Id { get; set; }
    }
}
