using AutoMapper;
using CA.MVC.Services.Base;
using CA.MVC.ViewModels;

namespace CA.MVC.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateLeaveTypeDTO, CreateLeaveTypeVM>().ReverseMap();
            CreateMap<LeaveTypeDTO, LeaveTypeVM>().ReverseMap();
        }
    }
}
