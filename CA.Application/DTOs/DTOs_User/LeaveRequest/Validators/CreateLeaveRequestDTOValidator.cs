using CA.Application.DTOs.DTOs_User.LeaveRequest.Interfaces;
using CA.Application.Contracts.Persistance.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA.Application.DTOs.DTOs_User.LeaveRequest.Validators
{
    public class CreateLeaveRequestDTOValidator: AbstractValidator<CreateLeaveRequestDTO>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public CreateLeaveRequestDTOValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            Include(new ILeaveRequestDTOValidator(_leaveTypeRepository));
        }
    }
}
