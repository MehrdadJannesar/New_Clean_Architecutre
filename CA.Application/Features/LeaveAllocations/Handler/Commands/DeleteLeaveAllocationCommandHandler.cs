using AutoMapper;
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
    public class DeleteLeaveAllocationCommandHandler : IRequestHandler<DeleteLeaveAllocationCommand,Unit>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public DeleteLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var deleteAllocation = await _leaveAllocationRepository.Get(request.Id);

            if (deleteAllocation == null)
                throw new NotFoundException(nameof(LeaveAllocations), request.Id);

            await _leaveAllocationRepository.Delete(deleteAllocation);
            return Unit.Value;
        }
    }
}
