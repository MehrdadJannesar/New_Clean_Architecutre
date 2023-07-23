using CA.Application.DTOs.DTOs_User.LeaveType;
using CA.Domain.Common;
using CA.Domain.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA.Application.DTOs.DTOs_User.LeaveRequest
{
    public class LeaveRequestDTO : BaseDomainDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DateRequested { get; set; }
        public DateTime? DateActioned { get; set; }
        public string RequestComments { get; set; }
        public bool? Approved { get; set; }
        public bool Cancelled { get; set; }
        public LeaveTypeDTO LeaveType { get; set; }
        public Guid LeaveTypeId { get; set; }
    }
}
