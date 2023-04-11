using DataAccess.Commands;
using DataAccess.Queries;
using DTOS;
using Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_DAPPER.Controllers
{
    [Route("api/v1/[controller]/")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MoviesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllMovies")]

        public async Task<ActionResult<IEnumerable<MoviesDTO>>> GetAllMoviesAsync()
        {
            return Ok(await _mediator.Send(new GetAllMoviesQuery()));
        }

        [HttpPost("PostMovie")]

        public async Task<ActionResult<Unit>> PostAMovie([FromBody] CreateMoviesCommand create)
        {
            return Ok(await _mediator.Send(create));
        }

        [HttpGet("GetMovieById/{Id:int}")]

        public async Task<ActionResult<MoviesDTO>> GetMovieById([FromRoute] GetMovieByIdQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
    }
}
