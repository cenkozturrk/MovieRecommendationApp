using Chinchilla.Logging;
using MediatR;
using Microsoft.Extensions.Logging;
using MovieRecommendationApp.DataAccess.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationApp.Business.MediatR.Queries.Movie.GetAllMovie
{
    public class GetAllMovieQueryHandler : IRequestHandler<GetAllMovieQueryRequest, GetAllMovieQueryResponse>
    {
        readonly IMovieReadRepository _movieReadRepository;
        readonly ILogger<GetAllMovieQueryHandler> _logger;
        public GetAllMovieQueryHandler(IMovieReadRepository movieReadRepository,
            ILogger<GetAllMovieQueryHandler> logger)
        {
            _movieReadRepository = movieReadRepository;
            _logger = logger;
        }
        public async Task<GetAllMovieQueryResponse> Handle(GetAllMovieQueryRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(" Get all movie...");
            var movies = _movieReadRepository.GetAll().Select(m => new
            {
                m.Id,
                m.Name,
                m.OriginalLanguage,
                m.OriginalTitle,
                m.OverView,
                m.Popularity,
                m.VoteCount

            }).ToList();

            return new();
        }
    }
}
