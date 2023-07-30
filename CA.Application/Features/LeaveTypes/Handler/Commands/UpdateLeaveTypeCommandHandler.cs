using AutoMapper;
using CA.Application.DTOs.DTOs_User.LeaveType.Validators;
using CA.Application.Exceptions;
using CA.Application.Features.LeaveTypes.Requests.Commands;
using CA.Application.Contracts.Persistance.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CA.Application.Features.LeaveTypes.Handler.Commands
{
    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        

        public UpdateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveTypeValidator();
            var validation = await validator.ValidateAsync(request.LeaveTypeDTO);

            if (!validation.IsValid)
            {
                throw new ValidationException(validation);
            }

            var leaveType = await _leaveTypeRepository.Get(request.LeaveTypeDTO.Id);
            _mapper.Map(request.LeaveTypeDTO, leaveType);
            await _leaveTypeRepository.Update(leaveType);

            return Unit.Value;
        }
    }
}
