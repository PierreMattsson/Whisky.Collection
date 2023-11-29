using MediatR;
using Microsoft.AspNetCore.Mvc;
using Whisky.Collection.Application.Features.MyWhisky.Commands.CreateMyWhisky;
using Whisky.Collection.Application.Features.MyWhisky.Commands.DeleteMyWhisky;
using Whisky.Collection.Application.Features.MyWhisky.Commands.UpdateMyWhisky;
using Whisky.Collection.Application.Features.MyWhisky.Queries.GetMyWhiskyAll;
using Whisky.Collection.Application.Features.MyWhisky.Queries.GetMyWhiskyDetails;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Whisky.Collection.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyWhiskyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MyWhiskyController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<MyWhiskyController>
        [HttpGet]
        public async Task<List<MyWhiskyDTO>> Get()
        {
            var leaveTypes = await _mediator.Send(new GetMyWhiskyQuery());
            return leaveTypes;
        }

        // GET api/<MyWhiskyController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MyWhiskyDetailsDTO>> Get(int id)
        {
            var leaveTypesDetails = await _mediator.Send(new GetMyWhiskyDetailsQuery(id));
            return leaveTypesDetails;
        }

        // POST api/<MyWhiskyController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateMyWhiskyCommand myWhisky)
        {
            var response = await _mediator.Send(myWhisky);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        // PUT api/<MyWhiskyController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Put(UpdateMyWhiskyCommand myWhisky)
        {
            await _mediator.Send(myWhisky);
            return NoContent();
        }

        // DELETE api/<MyWhiskyController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteMyWhiskyCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
