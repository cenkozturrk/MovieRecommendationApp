using MediatR;
using MovieRecommendationApp.DataAccess.Repositories.Abstract;
using M = MovieRecommendationApp.Domain.Entities;

namespace MovieRecommendationApp.Business.MediatR.Queries.Movie.GetByIdMovie
{
    public class GetByIdMovieQueryHandler : IRequestHandler<GetByIdMovieQueryRequest, GetByIdMovieQueryResponse>
    {
        readonly IMovieReadRepository _movieReadRepository;

        public GetByIdMovieQueryHandler(IMovieReadRepository movieReadRepository)
        {
            _movieReadRepository = movieReadRepository; 
        }

        public async Task<GetByIdMovieQueryResponse> Handle(GetByIdMovieQueryRequest request, CancellationToken cancellationToken)
        {
            M.Movie movie = await _movieReadRepository.GetByIdAsync(request.Id, false);
            return new()
            {
                Name = movie.Name,
                OriginalLanguage = movie.OriginalLanguage,
                OriginalTitle = movie.OriginalTitle,
                OverView = movie.OverView,
                Popularity = movie.Popularity,
                VoteCount = movie.VoteCount

            };
        }
    }
}
