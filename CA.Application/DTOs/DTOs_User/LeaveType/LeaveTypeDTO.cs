using CA.Application.DTOs.DTOs_User.LeaveType.Interfaces;
using CA.Domain.Common;
using CA.Domain.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA.Application.DTOs.DTOs_User.LeaveType
{
    public class LeaveTypeDTO : BaseDomainDTO, ILeaveTypeDTO
    {
        public string Name { get; set; }
        public int DefaultDay { get; set; }
    }
}
