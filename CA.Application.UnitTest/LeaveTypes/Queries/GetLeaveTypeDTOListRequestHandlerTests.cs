using AutoMapper;
using CA.Application.Contracts.Persistance.Repositories;
using CA.Application.DTOs.DTOs_User.LeaveType;
using CA.Application.Features.LeaveTypes.Handler.Quries;
using CA.Application.Features.LeaveTypes.Requests.Commands;
using CA.Application.Profiles;
using CA.Application.UnitTest.Mocks;
using Moq;
using Shouldly;

namespace CA.Application.UnitTest.LeaveTypes.Queries
{
    public class GetLeaveTypeDTOListRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ILeaveTypeRepository> _mockRepository;
        public GetLeaveTypeDTOListRequestHandlerTests()
        {
            _mockRepository = MockLeaveTypeRepository.GetLeaveTypeRepository();

            var mapperConfig = new MapperConfiguration(m =>
            {
                m.AddProfile<MappingProfiles>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetLeaveTypeListTest()
        {
            var handler = new GetLeaveTypeDTOListRequestHandler(_mapper, _mockRepository.Object);
            var result = await handler.Handle(new GetLeaveTypeDTOListRequest(), CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            result.ShouldBeOfType<List<LeaveTypeDTO>>();

        }
    }
}
