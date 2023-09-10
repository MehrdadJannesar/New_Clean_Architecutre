using CA.Application.Contracts.Persistance.Repositories;
using CA.Domain.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Application.UnitTest.Mocks
{
    public static class MockLeaveTypeRepository
    {
        public static Mock<ILeaveTypeRepository> GetLeaveTypeRepository()
        {
            var leaveTypes = new List<LeaveType>()
            {
                new LeaveType
                {
                    Id = new Guid("2DC71F22-58ED-459D-8A2F-D36C6B54DA24"),
                    DefaultDay = 10,
                    Name = "Test Vacation"
                },
                new LeaveType
                {
                    Id = new Guid("E9E544F6-93CA-4BBC-8382-7F93E7D5DE9B"),
                    DefaultDay = 15,
                    Name = "Test sick"
                }
            };

            var mockRepo = new Mock<ILeaveTypeRepository>();
            
            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(leaveTypes);

            mockRepo.Setup(r => r.Add(It.IsAny<LeaveType>()))
                .ReturnsAsync((LeaveType leaveType) =>
                {
                    leaveTypes.Add(leaveType);
                    return leaveType;
                });

            return mockRepo;
        }
    }
}
