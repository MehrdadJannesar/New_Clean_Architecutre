using AutoMapper;
using CA.Application.DTOs.DTOs_User.LeaveAllocation.Validators;
using CA.Application.Exceptions;
using CA.Application.Features.LeaveAllocations.Requests.Commands;
using CA.Application.Persistance.Contract.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CA.Application.Features.LeaveAllocations.Handler.Commands
{
    public class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommand, Unit>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public UpdateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<Unit> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveAllocationDTOValidator(_leaveTypeRepository);
            var validation = await validator.ValidateAsync(request.UpdateLeaveAllocationDTO);

            if (!validation.IsValid)
            {
                throw new ValidationException(validation);
            }

            var leaveAllocation = await _leaveAllocationRepository.Get(request.UpdateLeaveAllocationDTO.Id);
            _mapper.Map(request.UpdateLeaveAllocationDTO, leaveAllocation);
            await _leaveAllocationRepository.Update(leaveAllocation);
            
            return Unit.Value;
        }
    }
}
