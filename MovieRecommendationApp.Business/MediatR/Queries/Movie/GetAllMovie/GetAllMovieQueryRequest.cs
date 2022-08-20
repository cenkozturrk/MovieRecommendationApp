using MediatR;
using MovieRecommendationApp.Business.RequestParameters;

namespace MovieRecommendationApp.Business.MediatR.Queries.Movie.GetAllMovie
{
    public class GetAllMovieQueryRequest : IRequest<GetAllMovieQueryResponse>
    {
        //public Pagination Pagination { get; set; }
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;

    }
}
