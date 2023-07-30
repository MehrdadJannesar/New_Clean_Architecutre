using AutoMapper;
using CA.Application.DTOs.DTOs_User.LeaveRequest.Validators;
using CA.Application.Exceptions;
using CA.Application.Features.LeaveRequests.Requests.Commands;
using CA.Application.Contracts.Persistance.Repositories;
using CA.Application.Response;
using CA.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CA.Application.Contracts.Infrastructure;
using CA.Application.CommonModels;

namespace CA.Application.Features.LeaveRequests.Handler.Commands
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, BaseCommandResponse>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IEmailSender _emailSender;

        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper, ILeaveTypeRepository leaveTypeRepository, IEmailSender emailSender)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
            _emailSender = emailSender;
        }

        public async Task<BaseCommandResponse> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var resonse = new BaseCommandResponse();
            var validator = new CreateLeaveRequestDTOValidator(_leaveTypeRepository);
            var validation = await validator.ValidateAsync(request.CreateLeaveRequestDTO);

            if (!validation.IsValid)
            {
                resonse.Success = false;
                resonse.Message = "Creation is faild";
                resonse.Errors = validation.Errors.Select(e => e.ErrorMessage).ToList();
            }

            var leaveRequest = _mapper.Map<LeaveRequest>(request.CreateLeaveRequestDTO);
            leaveRequest = await _leaveRequestRepository.Add(leaveRequest);

            resonse.Success = true;
            resonse.Message = "Creation Success";
            resonse.Id = leaveRequest.Id;

            var email = new Email
            {
                To="jannesar.computer@gmail.com",
                subject="Leave Request Submitted",
                body = $"Your leave request for {request.CreateLeaveRequestDTO.StartDate} to {request.CreateLeaveRequestDTO.EndDate} has been accept."
            };

            try
            {
                await _emailSender.SendEmailAsync(email);
            }
            catch (Exception)
            {
                //log
                throw;
            }
            return resonse;
        }
    }
}
