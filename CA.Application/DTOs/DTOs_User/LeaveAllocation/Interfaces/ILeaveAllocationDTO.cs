using System;
using System.Collections.Generic;
using System.Text;

namespace CA.Application.DTOs.DTOs_User.LeaveAllocation.Interfaces
{
    public interface ILeaveAllocationDTO
    {
        public int NumberOfDays { get; set; }
        public int Priod { get; set; }
        public Guid LeaveTypeId { get; set; }

    }
}
