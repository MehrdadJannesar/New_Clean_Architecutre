using AutoMapper;
using CA.Application.DTOs.DTOs_User;
using CA.Application.DTOs.DTOs_User.LeaveRequest;
using CA.Application.Features.LeaveAllocations.Requests.Queries;
using CA.Application.Persistance.Contract.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CA.Application.Features.LeaveAllocations.Handler.Queries
{
    public class GetLeaveAllocationDTOListRequestHandler : IRequestHandler<GetLeaveAllocationDTOListRequest, List<LeaveAllocationDTO>>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public GetLeaveAllocationDTOListRequestHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        public async Task<List<LeaveAllocationDTO>> Handle(GetLeaveAllocationDTOListRequest request, CancellationToken cancellationToken)
        {
            var leaveAllocationList = await _leaveAllocationRepository.GetAll();
            return _mapper.Map<List<LeaveAllocationDTO>>(leaveAllocationList);
        }
    }
}
