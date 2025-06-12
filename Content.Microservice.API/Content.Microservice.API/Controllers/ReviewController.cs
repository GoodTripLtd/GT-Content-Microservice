using Content.Microservice.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Content.Microservice.AppCore.Commands;
using Content.Microservice.AppCore.Queries;

namespace Content.Microservice.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ReviewController : BaseController
    {
        public ReviewController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Review>>> GetAll()
            => Ok(await _mediator.Send(new GetAllReviewsQuery()));

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Review>> GetById(Guid id)
        {
            var review = await _mediator.Send(new GetReviewByIdQuery { Id = id });
            return review is null ? NotFound() : Ok(review);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateReviewCommand cmd)
        {
            var id = await _mediator.Send(cmd);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateReviewCommand cmd)
        {
            var ok = await _mediator.Send(cmd);
            return ok ? NoContent() : NotFound();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var ok = await _mediator.Send(new DeleteReviewCommand { Id = id });
            return ok ? NoContent() : NotFound();
        }
    }
}
