using Microsoft.AspNetCore.Mvc;
using MovieRecommendationApp.DataAccess.Repositories.Abstract;
using MovieRecommendationApp.Domain.Entities;

namespace MovieRecommendationApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private IMovieReadRepository _movieReadRepository;
        private IMovieWriteRepository _movieWriteRepository;
        
        public MovieController(IMovieReadRepository movieReadRepository, IMovieWriteRepository movieWriteRepository)
        {
            _movieReadRepository = movieReadRepository;
            _movieWriteRepository = movieWriteRepository;
        }
 
        [HttpGet] 
        public async Task Get()
        {        
            await _movieWriteRepository.AddAsync(new() { Name = "C" });
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Movie movie = await _movieReadRepository.GetByIdAsync(id);
            return Ok(movie);
        }

        
    }
}
