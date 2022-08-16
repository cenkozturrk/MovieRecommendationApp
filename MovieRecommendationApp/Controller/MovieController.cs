using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieRecommendationApp.Business.MovieRepository.Abstract;

namespace MovieRecommendationApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private IMovieReadRepository _movieRead;
        private IMovieWriteRepository _movieWrite;
        
        public MovieController(IMovieReadRepository movieRead, IMovieWriteRepository movieWrite)
        {
            _movieRead = movieRead;
            _movieWrite = movieWrite;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var movie = _movieRead.GetAll();
            return Ok(movie);
        }
       
    }
}
