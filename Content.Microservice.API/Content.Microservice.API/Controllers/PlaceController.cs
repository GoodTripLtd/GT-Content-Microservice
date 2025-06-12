using Content.Microservice.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Content.Microservice.AppCore.Commands;
using Content.Microservice.AppCore.Queries;
namespace Content.Microservice.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PlaceController : BaseController
    {
        public PlaceController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Place>>> GetAll()
            => Ok(await _mediator.Send(new GetAllPlacesQuery()));

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Place>> GetById(Guid id)
        {
            var place = await _mediator.Send(new GetPlaceByIdQuery { Id = id });
            return place is null ? NotFound() : Ok(place);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreatePlaceCommand cmd)
        {
            var id = await _mediator.Send(cmd);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePlaceCommand cmd)
        {
            var ok = await _mediator.Send(cmd);
            return ok ? NoContent() : NotFound();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var ok = await _mediator.Send(new DeletePlaceCommand { Id = id });
            return ok ? NoContent() : NotFound();
        }
    }
}
