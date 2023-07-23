using CA.Application.DTOs.DTOs_User.LeaveType;
using CA.Domain.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA.Application.DTOs.DTOs_User.LeaveRequest
{
    public class LeaveRequestListDTO : BaseDomainDTO
    {
        public LeaveTypeDTO LeaveTypeDTO { get; set; }
        public DateTime DateRequested { get; set; }
        public bool? Approved { get; set; }
    }
}
