using AutoMapper;
using CA.Application.DTOs.DTOs_User;
using CA.Application.DTOs.DTOs_User.LeaveType;
using CA.Application.Features.LeaveTypes.Requests;
using CA.Application.Features.LeaveTypes.Requests.Commands;
using CA.Application.Persistance.Contract.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CA.Application.Features.LeaveTypes.Handler.Quries
{
    public class GetLeaveTypeDTOListRequestHandler : IRequestHandler<GetLeaveTypeDTOListRequest, List<LeaveTypeDTO>>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public GetLeaveTypeDTOListRequestHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<List<LeaveTypeDTO>> Handle(GetLeaveTypeDTOListRequest request, CancellationToken cancellationToken)
        {
            var leaveTypeList = await _leaveTypeRepository.GetAll();
            return _mapper.Map<List<LeaveTypeDTO>>(leaveTypeList);
        }
    }
}
