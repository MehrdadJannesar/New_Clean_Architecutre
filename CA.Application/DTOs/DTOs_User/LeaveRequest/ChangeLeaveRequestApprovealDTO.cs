using CA.Domain.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA.Application.DTOs.DTOs_User.LeaveRequest
{
    public class ChangeLeaveRequestApprovalDTO:BaseDomainDTO
    {
        public bool? Approved { get; set; }
    }
}
