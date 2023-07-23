using AutoMapper;
using CA.Application.DTOs.DTOs_User;
using CA.Application.DTOs.DTOs_User.LeaveRequest;
using CA.Application.Features.LeaveAllocations.Requests.Queries;
using CA.Application.Features.LeaveAllocations.Handler.Queries;
using CA.Application.Persistance.Contract.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CA.Application.Features.LeaveAllocations.Handler.Queries
{
    public class GetLeaveAllocationDTODetailsRequestHandler : IRequestHandler<GetLeaveAllocationDTODetailsRequest, LeaveAllocationDTO>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public GetLeaveAllocationDTODetailsRequestHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        public async Task<LeaveAllocationDTO> Handle(GetLeaveAllocationDTODetailsRequest request, CancellationToken cancellationToken)
        {
            var leaveAllocation = await _leaveAllocationRepository.Get(request.Id);
            return _mapper.Map<LeaveAllocationDTO>(leaveAllocation);
        }
    }
}
