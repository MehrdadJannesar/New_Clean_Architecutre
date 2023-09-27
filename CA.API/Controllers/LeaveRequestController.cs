using CA.Application.DTOs.DTOs_User.LeaveRequest;
using CA.Application.Features.LeaveRequests.Requests.Commands;
using CA.Application.Features.LeaveRequests.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class LeaveRequestController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveRequestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<LeaveRequestController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveRequestDTO>>> Get()
        {
            var leaveRequests = await _mediator.Send(new GetLeaveRequestDTOListRequest());
            return Ok(leaveRequests);
        }

        // GET api/<LeaveRequestController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveRequestDTO>> Get(Guid id)
        {
            var leaveRequest = await _mediator.Send(new GetLeaveRequestDTODetailsRequest { Id = id });
            return Ok(leaveRequest);
        }

        // POST api/<LeaveRequestController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateLeaveRequestDTO createLeaveRequestDTO)
        {
            var command = new CreateLeaveRequestCommand {CreateLeaveRequestDTO = createLeaveRequestDTO };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<LeaveRequestController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] UpdateLeaveRequestDTO updateLeaveRequestDTO)
        {
            var command = new UpdateLeaveRequestCommand { Id = id,UpdateLeaveRequestDTO = updateLeaveRequestDTO };
            await _mediator.Send(command);
            return NoContent();
        }
        // PUT api/<LeaveRequestController>/changeapproval/5
        [HttpPut("changeapproval/{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] ChangeLeaveRequestApprovalDTO changeLeaveRequestApprovalDTO)
        {
            var command = new UpdateLeaveRequestCommand { Id = id,ChangeLeaveRequestApprovalDTO= changeLeaveRequestApprovalDTO };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<LeaveRequestController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleateLeaveRequestCommand {Id = id};
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
