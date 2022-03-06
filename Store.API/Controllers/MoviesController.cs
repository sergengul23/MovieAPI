using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.BUSINESS.CQRS.MovieOperations.Commands;
using Store.BUSINESS.CQRS.MovieOperations.Queries;
using Store.BUSINESS.DTOs.RequestDTOs;

namespace Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MoviesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllMovies()
        {
            var result = await _mediator.Send(new GetAllMoviesQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var result = await _mediator.Send(new GetMovieQuery(id));
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateMovie([FromBody] CreateMovieDTO createMovieDTO)
        {
            var result = await _mediator.Send(new CreateMovieCommand(createMovieDTO));
            return Ok(result);
        }

        [HttpPost]
        [Route("AddActor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddActor(int movieId, int actorId)
        {
            var result = await _mediator.Send(new AddActorCommand(movieId, actorId));
            return Ok(result);
        }

        [HttpPost]
        [Route("AddGenre")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddGenre(int movieId, int genreId)
        {
            var result = await _mediator.Send(new AddGenreCommand(movieId, genreId));
            return Ok(result);
        }

        [HttpPost]
        [Route("RemoveActor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RemoveActor(int movieId, int actorId)
        {
            var result = await _mediator.Send(new RemoveActorCommand(movieId, actorId));
            return Ok(result);
        }

        [HttpPost]
        [Route("RemoveGenre")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RemoveGenre(int movieId, int genreId)
        {
            var result = await _mediator.Send(new RemoveGenreCommand(movieId, genreId));
            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateMovie([FromBody] UpdateMovieDTO updateMovieDTO)
        {
            var result = await _mediator.Send(new UpdateMovieCommand(updateMovieDTO));
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var result = await _mediator.Send(new DeleteMovieCommand(id));
            return Ok(result);
        }
    }
}
