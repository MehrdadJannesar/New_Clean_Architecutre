using CA.Application.DTOs.DTOs_User.LeaveRequest.Interfaces;
using CA.Domain.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA.Application.DTOs.DTOs_User.LeaveRequest
{
    public class UpdateLeaveRequestDTO:BaseDomainDTO, ILeaveRequestDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Cancelled { get; set; }
        public string RequestComments { get; set; }
        public Guid LeaveTypeId { get; set; }

    }
}
