using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.BUSINESS.CQRS.GenreOperations.Commands;
using Store.BUSINESS.CQRS.GenreOperations.Queries;
using Store.BUSINESS.DTOs.RequestDTOs;

namespace Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GenresController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllGenres()
        {
            var result = await _mediator.Send(new GetAllGenresQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetGenreById(int id)
        {
            var result = await _mediator.Send(new GetGenreQuery(id));
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateGenre([FromBody] CreateGenreDTO createGenreDTO)
        {
            var result = await _mediator.Send(new CreateGenreCommand(createGenreDTO));
            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateGenre([FromBody] UpdateGenreDTO updateGenreDTO)
        {
            var result = await _mediator.Send(new UpdateGenreCommand(updateGenreDTO));
            return Ok(result);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteGenre([FromQuery] int id)
        {
            await _mediator.Send(new DeleteGenreCommand(id));
            return NoContent();
        }
    }
}
