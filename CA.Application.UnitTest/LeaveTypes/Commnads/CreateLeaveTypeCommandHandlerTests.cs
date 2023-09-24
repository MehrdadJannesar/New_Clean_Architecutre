using AutoMapper;
using CA.Application.Contracts.Persistance.Repositories;
using CA.Application.DTOs.DTOs_User.LeaveType;
using CA.Application.Features.LeaveAllocations.Requests.Commands;
using CA.Application.Features.LeaveTypes.Handler.Commands;
using CA.Application.Features.LeaveTypes.Requests.Commands;
using CA.Application.Profiles;
using CA.Application.Response;
using CA.Application.UnitTest.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Application.UnitTest.LeaveTypes.Commnads
{
    public class CreateLeaveTypeCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ILeaveTypeRepository> _leaveTypeRepository;
        private readonly CreateLeaveTypeDTO _createLeaveTypeDTO;

        public CreateLeaveTypeCommandHandlerTests()
        {
            _createLeaveTypeDTO = new CreateLeaveTypeDTO()
            {
                DefaultDay = 10,
                Name = "test"
            };

            _leaveTypeRepository = MockLeaveTypeRepository.GetLeaveTypeRepository();

            var mapperConfig = new MapperConfiguration(m =>
            {
                m.AddProfile<MappingProfiles>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task CreateLeaveTypeTest()
        {
            var handler = new CreateLeaveTypeCommandHandler(_leaveTypeRepository.Object, _mapper);

            var result = await handler.Handle(new CreateLeaveTypeCommand()
            {
                CreateLeaveTypeDTO = _createLeaveTypeDTO
            }, CancellationToken.None);

            result.ShouldBeOfType<BaseCommandResponse>();
        }
    }
}
