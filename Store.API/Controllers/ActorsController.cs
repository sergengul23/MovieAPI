using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.BUSINESS.CQRS.ActorOperations.Commands;
using Store.BUSINESS.CQRS.ActorOperations.Queries;
using Store.BUSINESS.DTOs.RequestDTOs;

namespace Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ActorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllActors()
        {
            var result = await _mediator.Send(new GetAllActorsQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetActorById(int id)
        {
            var result = await _mediator.Send(new GetActorQuery(id));
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateActor([FromBody] CreateActorDTO createActorDTO)
        {
            var result = await _mediator.Send(new CreateActorCommand(createActorDTO));
            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateActor([FromBody] UpdateActorDTO updateActorDTO)
        {
            var result = await _mediator.Send(new UpdateActorCommand(updateActorDTO));
            return Ok(result);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteGenre([FromQuery] int id)
        {
            await _mediator.Send(new DeleteActorCommand(id));
            return NoContent();
        }
    }
}
