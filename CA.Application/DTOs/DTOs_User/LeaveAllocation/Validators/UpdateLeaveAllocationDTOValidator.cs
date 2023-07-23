using CA.Application.Persistance.Contract.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA.Application.DTOs.DTOs_User.LeaveAllocation.Validators
{
    public class UpdateLeaveAllocationDTOValidator:AbstractValidator<UpdateLeaveAllocationDTO>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public UpdateLeaveAllocationDTOValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            Include(new ILeaveAllocationDTOValidator(_leaveTypeRepository));

            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName is required}");
        }
    }
}
