using AutoMapper;
using CA.Application.DTOs.DTOs_User.LeaveAllocation;
using CA.Application.DTOs.DTOs_User.LeaveRequest;
using CA.Application.DTOs.DTOs_User.LeaveType;
using CA.Domain.Models;


namespace CA.Application.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {

            #region LeaveRequest
            CreateMap<LeaveRequest, LeaveRequestDTO>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestListDTO>().ReverseMap();
            CreateMap<LeaveRequest, CreateLeaveRequestDTO>().ReverseMap();
            CreateMap<LeaveRequest, UpdateLeaveRequestDTO>().ReverseMap();
            #endregion

            #region LeaveAllocation
            CreateMap<LeaveAllocation, LeaveAllocationDTO>().ReverseMap();
            CreateMap<LeaveAllocation, CreateLeaveAllocationDTO>().ReverseMap();
            CreateMap<LeaveAllocation, UpdateLeaveAllocationDTO>().ReverseMap();
            #endregion

            #region LeaveType
            CreateMap<LeaveType, LeaveTypeDTO>().ReverseMap();
            CreateMap<LeaveType, CreateLeaveTypeDTO>().ReverseMap();
            #endregion
        }
    }
}
