using CA.Application.DTOs.DTOs_User.LeaveAllocation.Interfaces;
using CA.Application.Contracts.Persistance.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA.Application.DTOs.DTOs_User.LeaveAllocation.Validators
{
    public class ILeaveAllocationDTOValidator : AbstractValidator<ILeaveAllocationDTO>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public ILeaveAllocationDTOValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            RuleFor(p => p.Priod).GreaterThanOrEqualTo(DateTime.Now.Year).WithMessage("{PropertyName} must be after {ComparisonValue}")
                .NotNull().WithMessage("{PropertyName} is required");
            
            RuleFor(p => p.NumberOfDays).GreaterThan(0).WithMessage("{PropertyName} must be greater than 0")
            .NotNull().WithMessage("{PropertyName} is required");

            RuleFor(p => p.LeaveTypeId)
            .MustAsync(async (id, token) =>
            {
                var leaveTypeExist = await _leaveTypeRepository.Exist(id);
                return !leaveTypeExist;
            })
            .WithMessage("{PropertyName} does not exist.");
        }
    }
}
