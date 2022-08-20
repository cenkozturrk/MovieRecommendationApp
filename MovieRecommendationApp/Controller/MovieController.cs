using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieRecommendationApp.Business.MediatR.Commands;
using MovieRecommendationApp.Business.MediatR.Queries.GetAllMovie;
using MovieRecommendationApp.DataAccess.Repositories.Abstract;
using MovieRecommendationApp.Domain.Entities;
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


        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(string id)
        //{
        //    Movie movie = await _movieReadRepository.GetByIdAsync(id);
        //    return Ok(movie);
        //}

        [HttpPost]
        public async Task<IActionResult> Post(CreateMovieCommandRequest createMovieCommandRequest)
        {
             CreateMovieCommandResponse response = await _mediator.Send(createMovieCommandRequest);
            return StatusCode((int)HttpStatusCode.Created);
        }
    }
}
