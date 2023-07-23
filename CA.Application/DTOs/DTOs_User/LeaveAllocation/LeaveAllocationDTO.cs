using CA.Application.DTOs.DTOs_User.LeaveType;
using CA.Domain.Common;
using CA.Domain.DTOs.Common;
using System;

namespace CA.Application.DTOs.DTOs_User.LeaveRequest
{
    public class LeaveAllocationDTO : BaseDomainDTO
    {
        public int NumberOfDays { get; set; }
        public int Priod { get; set; }
        public LeaveTypeDTO LeaveType { get; set; }
        public Guid LeaveTypeId { get; set; }
    }
}
