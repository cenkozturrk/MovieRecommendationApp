using MediatR;
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
        public GetAllMovieQueryHandler(IMovieReadRepository movieReadRepository)
        {
            _movieReadRepository = movieReadRepository;
        }
        public async Task<GetAllMovieQueryResponse> Handle(GetAllMovieQueryRequest request, CancellationToken cancellationToken)
        {
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
