using Content.Microservice.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Content.Microservice.AppCore.Commands;
using Content.Microservice.AppCore.Queries;

namespace Content.Microservice.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TagController : BaseController
    {
        public TagController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tag>>> GetAll()
            => Ok(await _mediator.Send(new GetAllTagsQuery()));

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Tag>> GetById(Guid id)
        {
            var tag = await _mediator.Send(new GetTagByIdQuery { Id = id });
            return tag is null ? NotFound() : Ok(tag);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateTagCommand cmd)
        {
            var id = await _mediator.Send(cmd);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTagCommand cmd)
        {
            var ok = await _mediator.Send(cmd);
            return ok ? NoContent() : NotFound();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var ok = await _mediator.Send(new DeleteTagCommand { Id = id });
            return ok ? NoContent() : NotFound();
        }
    }
}
