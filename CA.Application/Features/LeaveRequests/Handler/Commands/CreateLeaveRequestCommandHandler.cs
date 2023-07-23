using AutoMapper;
using CA.Application.DTOs.DTOs_User.LeaveRequest.Validators;
using CA.Application.Exceptions;
using CA.Application.Features.LeaveRequests.Requests.Commands;
using CA.Application.Persistance.Contract.Repositories;
using CA.Application.Response;
using CA.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CA.Application.Features.LeaveRequests.Handler.Commands
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, BaseCommandResponse>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<BaseCommandResponse> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var resonse = new BaseCommandResponse();
            var validator = new CreateLeaveRequestDTOValidator(_leaveTypeRepository);
            var validation = await validator.ValidateAsync(request.CreateLeaveRequestDTO);

            if (!validation.IsValid)
            {
                resonse.Success = false;
                resonse.Message = "Creation is faild";
                resonse.Errors = validation.Errors.Select(e => e.ErrorMessage).ToList();
            }

            var leaveRequest = _mapper.Map<LeaveRequest>(request.CreateLeaveRequestDTO);
            leaveRequest = await _leaveRequestRepository.Add(leaveRequest);

            resonse.Success = true;
            resonse.Message = "Creation Success";
            resonse.Id = leaveRequest.Id;

            return resonse;
        }
    }
}
