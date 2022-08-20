using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieRecommendationApp.Business.MediatR.Commands.Movie.CreateMovie;
using MovieRecommendationApp.Business.MediatR.Commands.Movie.UpdateMovie;
using MovieRecommendationApp.Business.MediatR.Queries.Movie.GetAllMovie;
using MovieRecommendationApp.Business.MediatR.Queries.Movie.GetByIdMovie;
using System.Net;

namespace MovieRecommendationApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        readonly IMediator _mediator;

        public MovieController(IMediator mediator)
        {            
            _mediator = mediator;
        }

        [HttpGet] 
        public async Task<IActionResult> Get([FromQuery] GetAllMovieQueryRequest getAllMovieQueryRequest)
        {        
          GetAllMovieQueryResponse response = await _mediator.Send(getAllMovieQueryRequest);
            return Ok(response);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdMovieQueryRequest getByIdMovieQueryRequest)
        {
            GetByIdMovieQueryResponse response = await _mediator.Send(getByIdMovieQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateMovieCommandRequest createMovieCommandRequest)
        {
             CreateMovieCommandResponse response = await _mediator.Send(createMovieCommandRequest);
            return StatusCode((int)HttpStatusCode.Created);
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateMovieCommandRequest updateMovieCommandRequest)
        {
            UpdateMovieCommandResponse response = await _mediator.Send(updateMovieCommandRequest);
            return Ok();
        }
    }
}
