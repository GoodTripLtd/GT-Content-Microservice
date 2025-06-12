using Content.Microservice.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Content.Microservice.AppCore.Commands;
using Content.Microservice.AppCore.Queries;

namespace Content.Microservice.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ReplyController : BaseController
    {
        public ReplyController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reply>>> GetAll()
            => Ok(await _mediator.Send(new GetAllRepliesQuery()));

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Reply>> GetById(Guid id)
        {
            var reply = await _mediator.Send(new GetReplyByIdQuery { Id = id });
            return reply is null ? NotFound() : Ok(reply);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateReplyCommand cmd)
        {
            var id = await _mediator.Send(cmd);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateReplyCommand cmd)
        {
            var ok = await _mediator.Send(cmd);
            return ok ? NoContent() : NotFound();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var ok = await _mediator.Send(new DeleteReplyCommand { Id = id });
            return ok ? NoContent() : NotFound();
        }
    }
}
