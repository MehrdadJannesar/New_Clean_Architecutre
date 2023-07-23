using CA.Application.DTOs.DTOs_User.LeaveType.Interfaces;
using CA.Domain.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA.Application.DTOs.DTOs_User.LeaveType
{
    public class CreateLeaveTypeDTO : ILeaveTypeDTO
    {
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int DefaultDay { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
