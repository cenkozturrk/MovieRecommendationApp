using MediatR;
using Microsoft.Extensions.Logging;
using MovieRecommendationApp.DataAccess.Repositories.Abstract;
using M = MovieRecommendationApp.Domain.Entities;

namespace MovieRecommendationApp.Business.MediatR.Commands.Movie.UpdateMovie
{
    public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommandRequest, UpdateMovieCommandResponse>
    {
        readonly IMovieWriteRepository _movieWriteRepository;
        readonly IMovieReadRepository _movieReadRepository;
        readonly ILogger<UpdateMovieCommandHandler> _logger; // Artık serilog calısıcak bir log gonderdiğimiz de.

        public UpdateMovieCommandHandler(IMovieWriteRepository movieWriteRepository, IMovieReadRepository movieReadRepository, ILogger<UpdateMovieCommandHandler> logger)
        {
            _movieWriteRepository = movieWriteRepository;
            _movieReadRepository = movieReadRepository;
            _logger = logger;
        }

        public async Task<UpdateMovieCommandResponse> Handle(UpdateMovieCommandRequest request, CancellationToken cancellationToken)
        {
            M.Movie movie = await _movieReadRepository.GetByIdAsync(request.Id);
            movie.Name = request.Name;
            movie.OriginalLanguage = request.OriginalLanguage;
            movie.OriginalTitle = request.OriginalTitle;
            movie.OverView = request.OverView;
            movie.Popularity = request.Popularity;
            movie.VoteCount = request.VoteCount;
            await _movieWriteRepository.SaveAsync();
            _logger.LogInformation(" The Movie list is updated... ");
            return new();
        }
    }
}
