using CA.Application.DTOs.DTOs_User.LeaveAllocation.Interfaces;
using CA.Domain.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA.Application.DTOs.DTOs_User.LeaveAllocation
{
    public class UpdateLeaveAllocationDTO:BaseDomainDTO, ILeaveAllocationDTO
    {
        public int NumberOfDays { get; set; }
        public Guid LeaveTypeId { get; set; }
        public int Priod { get; set; }
    }
}
