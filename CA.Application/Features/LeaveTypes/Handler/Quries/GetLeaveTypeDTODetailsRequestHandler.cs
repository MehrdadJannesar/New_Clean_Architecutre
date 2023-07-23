using AutoMapper;
using CA.Application.DTOs.DTOs_User;
using CA.Application.DTOs.DTOs_User.LeaveType;
using CA.Application.Features.LeaveTypes.Requests.Queries;
using CA.Application.Persistance.Contract.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CA.Application.Features.LeaveTypes.Handler.Quries
{
    public class GetLeaveTypeDTODetailsRequestHandler : IRequestHandler<GetLeaveTypeDTODetailsRequest, LeaveTypeDTO>
    {

        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public GetLeaveTypeDTODetailsRequestHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<LeaveTypeDTO> Handle(GetLeaveTypeDTODetailsRequest request, CancellationToken cancellationToken)
        {
            var LeaveType = await _leaveTypeRepository.Get(request.Id);
            return _mapper.Map<LeaveTypeDTO>(LeaveType);
        }
    }
}
