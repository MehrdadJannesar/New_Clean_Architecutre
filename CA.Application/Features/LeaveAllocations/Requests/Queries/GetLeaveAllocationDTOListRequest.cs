using CA.Application.DTOs.DTOs_User;
using CA.Application.DTOs.DTOs_User.LeaveRequest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA.Application.Features.LeaveAllocations.Requests.Queries
{
    public class GetLeaveAllocationDTOListRequest: IRequest<List<LeaveAllocationDTO>>
    {
    }
}
