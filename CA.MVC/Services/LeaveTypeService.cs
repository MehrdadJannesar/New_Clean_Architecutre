using AutoMapper;
using CA.MVC.Contracts;
using CA.MVC.Services.Base;
using CA.MVC.ViewModels;

namespace CA.MVC.Services
{
    public class LeaveTypeService : BaseHttpService, ILeaveTypeService
    {
        private readonly IMapper _mapper;
        private readonly IClient _client;
        private ILocalStorageService _localStorageService;
        public LeaveTypeService(IClient client, ILocalStorageService localStorageService, IMapper mapper) : base(client, localStorageService)
        {
            _client = client;
            _localStorageService = localStorageService;
            _mapper = mapper;
        }


        public async Task<ResponseApi<Guid>> CreateLeaveType(CreateLeaveTypeVM leaveTypeVM)
        {
            try
            {
                var response = new ResponseApi<Guid>();

                CreateLeaveTypeDTO createLeaveTypeDTO = _mapper.Map<CreateLeaveTypeDTO>(leaveTypeVM);

                //TODO Auth
                AddBearerToken();

                var ApiResponse = await _client.LeaveTypesPOSTAsync(createLeaveTypeDTO);
                if (ApiResponse.Success)
                {
                    response.Data = ApiResponse.Id;
                    response.Success = true;
                }
                else
                {
                    foreach (var err in ApiResponse.Errors)
                    {
                        response.ValidationErrors += err + Environment.NewLine;
                    }
                }
                return response;
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<ResponseApi<Guid>> DeleteLeaveTypeAsync(Guid Id)
        {
            try
            {
                AddBearerToken();
                await _client.LeaveTypesDELETEAsync(Id);
                return new ResponseApi<Guid>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<LeaveTypeVM> GetLeaveTypeDetailsAsync(Guid Id)
        {
            AddBearerToken();
            var ApiResponse = await _client.LeaveTypesGETAsync(Id);
            return _mapper.Map<LeaveTypeVM>(ApiResponse);
        }

        public async Task<List<LeaveTypeVM>> GetLeaveTypesAsync()
        {
            AddBearerToken();
            var ApiResponse = await _client.LeaveTypesAllAsync();
            return _mapper.Map<List<LeaveTypeVM>>(ApiResponse);
        }

        public async Task<ResponseApi<Guid>> UpdateLeaveTypeAsync(LeaveTypeVM leaveTypeVM)
        {

            try
            {
                var request = _mapper.Map<LeaveTypeDTO>(leaveTypeVM);
                AddBearerToken();
                await _client.LeaveTypesPUTAsync(request.Id, request);
                return new ResponseApi<Guid>() { Success = true };

            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }


        }
    }
}
