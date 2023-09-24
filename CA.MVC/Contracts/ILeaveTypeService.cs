using CA.MVC.Services.Base;
using CA.MVC.ViewModels;

namespace CA.MVC.Contracts
{
    public interface ILeaveTypeService
    {
        Task<List<LeaveTypeVM>> GetLeaveTypesAsync();
        Task<LeaveTypeVM> GetLeaveTypeDetailsAsync(Guid Id);
        Task<ResponseApi<Guid>> CreateLeaveType(CreateLeaveTypeVM leaveTypeVM);
        Task<ResponseApi<Guid>> UpdateLeaveTypeAsync(LeaveTypeVM leaveTypeVM);
        Task<ResponseApi<Guid>> DeleteLeaveTypeAsync(Guid Id);
    }
}
