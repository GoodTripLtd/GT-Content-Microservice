using Content.Microservice.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Content.Microservice.AppCore.Commands;
using Content.Microservice.AppCore.Queries;

namespace Content.Microservice.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class VotesController : BaseController
    {
        public VotesController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vote>>> GetAll()
            => Ok(await _mediator.Send(new GetAllVotesQuery()));

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Vote>> GetById(Guid id)
        {
            var vote = await _mediator.Send(new GetVoteByIdQuery { Id = id });
            return vote is null ? NotFound() : Ok(vote);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateVoteCommand cmd)
        {
            var id = await _mediator.Send(cmd);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateVoteCommand cmd)
        {
            var ok = await _mediator.Send(cmd);
            return ok ? NoContent() : NotFound();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var ok = await _mediator.Send(new DeleteVoteCommand { Id = id });
            return ok ? NoContent() : NotFound();
        }
    }
}
