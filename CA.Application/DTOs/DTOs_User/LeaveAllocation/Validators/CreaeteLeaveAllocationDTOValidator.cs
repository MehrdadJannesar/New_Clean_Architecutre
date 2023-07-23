using CA.Application.Persistance.Contract.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA.Application.DTOs.DTOs_User.LeaveAllocation.Validators
{
    public class CreaeteLeaveAllocationDTOValidator:AbstractValidator<CreateLeaveAllocationDTO>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreaeteLeaveAllocationDTOValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            Include(new ILeaveAllocationDTOValidator(_leaveTypeRepository));
        }
    }
}
