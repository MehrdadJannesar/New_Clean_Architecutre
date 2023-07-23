using CA.Application.DTOs.DTOs_User.LeaveType.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA.Application.DTOs.DTOs_User.LeaveType.Validators
{
    public class ILeaveTypeDTOValidators:AbstractValidator<ILeaveTypeDTO>
    {
        public ILeaveTypeDTOValidators()
        {
            RuleFor(p => p.Name).NotEmpty().NotNull()
                .WithMessage("{PropertyName} is required")
                .MaximumLength(50).WithMessage("{PropertyName} must be less than 50");

            RuleFor(p => p.DefaultDay).NotEmpty().NotNull().WithMessage("{PropertyName} is required")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 1")
                .LessThan(100).WithMessage("{PropertyName} must be less than 100");
        }
    }
}
