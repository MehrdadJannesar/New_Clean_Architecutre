using AutoMapper;
using CA.Application.DTOs.DTOs_User;
using CA.Application.DTOs.DTOs_User.LeaveRequest;
using CA.Application.Features.LeaveRequests.Requests.Queries;
using CA.Application.Persistance.Contract.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CA.Application.Features.LeaveRequests.Handler.Queries
{
    public class GetLeaveRequestDTOListRequestHandler : IRequestHandler<GetLeaveRequestDTOListRequest, List<LeaveRequestDTO>>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public GetLeaveRequestDTOListRequestHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task<List<LeaveRequestDTO>> Handle(GetLeaveRequestDTOListRequest request, CancellationToken cancellationToken)
        {
            var leaveRequestList = await _leaveRequestRepository.GetAll();
            return _mapper.Map<List<LeaveRequestDTO>>(leaveRequestList);
        }
    }
}
