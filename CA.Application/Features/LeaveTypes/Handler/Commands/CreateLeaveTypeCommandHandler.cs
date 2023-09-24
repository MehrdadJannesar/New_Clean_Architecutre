using AutoMapper;
using CA.Application.DTOs.DTOs_User.LeaveType.Validators;
using CA.Application.Exceptions;
using CA.Application.Features.LeaveTypes.Requests.Commands;
using CA.Application.Contracts.Persistance.Repositories;
using CA.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CA.Application.Response;
using System.Linq;

namespace CA.Application.Features.LeaveTypes.Handler.Commands
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, BaseCommandResponse>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateLeaveTypeValidator();
            var validation = await validator.ValidateAsync(request.CreateLeaveTypeDTO);

            if (!validation.IsValid)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validation.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                var leaveType = _mapper.Map<LeaveType>(request.CreateLeaveTypeDTO);
                leaveType = await _leaveTypeRepository.Add(leaveType);
                response.Success = true;
                response.Message = "Creation Success";
                response.Id = leaveType.Id;
            }

            return response;
        }
    }
}
