using CA.Domain.Common;
using System;

namespace CA.Domain.Models
{
    public class LeaveAllocation: BaseDomainEntity
    {
        public int NumberOfDays { get; set; }
        public int Priod { get; set; }

        public LeaveType LeaveType { get; set; }
        public Guid LeaveTypeId { get; set; }
    }
}
