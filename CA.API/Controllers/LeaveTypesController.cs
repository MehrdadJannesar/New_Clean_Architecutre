using CA.Application.DTOs.DTOs_User.LeaveType;
using CA.Application.Features.LeaveTypes.Requests.Commands;
using CA.Application.Features.LeaveTypes.Requests.Queries;
using CA.Application.Response;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LeaveTypesController : ControllerBase
    {

        private IMediator _mediator;

        public LeaveTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<LeaveTypesController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveTypeDTO>>> Get()
        {
            var leaveTypes = await _mediator.Send(new GetLeaveTypeDTOListRequest());
            return Ok(leaveTypes);
        }

        // GET api/<LeaveTypesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveTypeDTO>> Get(Guid id)
        {
            var leaveType = await _mediator.Send(new GetLeaveTypeDTODetailsRequest{ Id = id });
            return Ok(leaveType);   
        }

        // POST api/<LeaveTypesController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateLeaveTypeDTO createLeaveTypeDTO)
        {
            var command = new CreateLeaveTypeCommand { CreateLeaveTypeDTO = createLeaveTypeDTO};
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<LeaveTypesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id,[FromBody] LeaveTypeDTO leaveTypeDTO)
        {
            var command = new UpdateLeaveTypeCommand {LeaveTypeDTO = leaveTypeDTO };
            await _mediator.Send(command);
            return NoContent();

        }

        // DELETE api/<LeaveTypesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteLeaveTypeCommand {Id=id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
