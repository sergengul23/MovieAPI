using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.BUSINESS.CQRS.DirectorOperations.Commands;
using Store.BUSINESS.CQRS.DirectorOperations.Queries;
using Store.BUSINESS.DTOs.RequestDTOs;

namespace Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DirectorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllDirectors()
        {
            var result = await _mediator.Send(new GetAllDirectorsQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetDirectorById(int id)
        {
            var result = await _mediator.Send(new GetDirectorQuery(id));
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateDirector([FromBody] CreateDirectorDTO createDirectorDTO)
        {
            var result = await _mediator.Send(new CreateDirectorCommand(createDirectorDTO));
            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateDirector([FromBody] UpdateDirectorDTO updateDirectorDTO)
        {
            var result = await _mediator.Send(new UpdateDirectorCommand(updateDirectorDTO));
            return Ok(result);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteDirector([FromQuery] int id)
        {
            await _mediator.Send(new DeleteDirectorCommand(id));
            return NoContent();
        }
    }
}
