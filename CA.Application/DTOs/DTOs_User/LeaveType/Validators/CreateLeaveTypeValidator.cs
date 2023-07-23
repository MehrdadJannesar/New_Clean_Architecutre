using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA.Application.DTOs.DTOs_User.LeaveType.Validators
{
    public class CreateLeaveTypeValidator:AbstractValidator<CreateLeaveTypeDTO>
    {
        public CreateLeaveTypeValidator()
        {
            Include(new ILeaveTypeDTOValidators());
        }
    }
}
