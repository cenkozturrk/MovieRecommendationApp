using Microsoft.AspNetCore.Mvc;
using MovieRecommendationApp.DataAccess.Repositories.Abstract;

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
        public async void Get()
        {
            await _movieWriteRepository.AddRangeAsync(new()
            {
                new() { Id = Guid.NewGuid(), Name = " Movie "}
            });
           await _movieWriteRepository.SaveAsync();
        }
       
    }
}
