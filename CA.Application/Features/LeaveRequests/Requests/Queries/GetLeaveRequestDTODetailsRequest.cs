using CA.Application.DTOs.DTOs_User;
using CA.Application.DTOs.DTOs_User.LeaveRequest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA.Application.Features.LeaveRequests.Requests.Queries
{
    public class GetLeaveRequestDTODetailsRequest : IRequest<LeaveRequestDTO>
    {
        public Guid Id { get; set; }
    }
}
