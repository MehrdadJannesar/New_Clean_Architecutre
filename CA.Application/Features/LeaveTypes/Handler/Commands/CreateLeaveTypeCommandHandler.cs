using AutoMapper;
using CA.Application.DTOs.DTOs_User.LeaveType.Validators;
using CA.Application.Exceptions;
using CA.Application.Features.LeaveTypes.Requests.Commands;
using CA.Application.Persistance.Contract.Repositories;
using CA.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CA.Application.Features.LeaveTypes.Handler.Commands
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, Guid>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveTypeValidator();
            var validation = await validator.ValidateAsync(request.CreateLeaveTypeDTO);

            if (!validation.IsValid)
            {
                throw new ValidationException(validation);
            }
            
            var leaveType = _mapper.Map<LeaveType>(request.CreateLeaveTypeDTO);
            leaveType = await _leaveTypeRepository.Add(leaveType);
            return leaveType.Id;
        }
    }
}
