using CA.Application.DTOs.DTOs_User.LeaveAllocation;
using CA.Application.DTOs.DTOs_User.LeaveRequest;
using CA.Application.Features.LeaveAllocations.Requests.Commands;
using CA.Application.Features.LeaveAllocations.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class LeaveAllocationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveAllocationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<LeaveAllocationController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveAllocationDTO>>> Get()
        {
            var leaveAllocations = await _mediator.Send(new GetLeaveAllocationDTOListRequest());
            return Ok(leaveAllocations);
        }

        // GET api/<LeaveAllocationController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveAllocationDTO>> Get(Guid id)
        {
            var leaveAllocation = await _mediator.Send(new GetLeaveAllocationDTODetailsRequest { Id = id });
            return Ok(leaveAllocation);
        }

        // POST api/<LeaveAllocationController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateLeaveAllocationDTO createLeaveAllocationDTO)
        {
            var command = new CreateLeaveAllocationCommand { CreateLeaveAllocationDTO = createLeaveAllocationDTO };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<LeaveAllocationController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] UpdateLeaveAllocationDTO updateLeaveAllocationDTO)
        {
            var command = new UpdateLeaveAllocationCommand { UpdateLeaveAllocationDTO = updateLeaveAllocationDTO };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<LeaveAllocationController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteLeaveAllocationCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
