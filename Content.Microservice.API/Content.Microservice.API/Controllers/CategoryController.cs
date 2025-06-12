using Content.Microservice.AppCore.Commands;
using Content.Microservice.AppCore.Queries;
using Content.Microservice.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Content.Microservice.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CategoryController : BaseController
    {
        public CategoryController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAll()
            => Ok(await _mediator.Send(new GetAllCategoriesQuery()));

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Category>> GetById(Guid id)
        {
            var cat = await _mediator.Send(new GetCategoryByIdQuery { Id = id });
            return cat is null ? NotFound() : Ok(cat);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateCategoryCommand cmd)
        {
            var id = await _mediator.Send(cmd);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryCommand cmd)
        {
            var ok = await _mediator.Send(cmd);
            return ok ? NoContent() : NotFound();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var ok = await _mediator.Send(new DeleteCategoryCommand { Id = id });
            return ok ? NoContent() : NotFound();
        }
    }
}
