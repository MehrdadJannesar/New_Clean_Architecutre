using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA.Application.DTOs.DTOs_User.LeaveType.Validators
{
    public class UpdateLeaveTypeValidator: AbstractValidator<LeaveTypeDTO>
    {
        public UpdateLeaveTypeValidator()
        {
            Include(new ILeaveTypeDTOValidators());

            RuleFor(p => p.Id).NotNull()
                .WithMessage("{PropertyName} is required");
        }
    }
}
