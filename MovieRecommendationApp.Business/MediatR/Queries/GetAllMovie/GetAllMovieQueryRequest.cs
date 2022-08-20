using MediatR;
using MovieRecommendationApp.Business.RequestParameters;

namespace MovieRecommendationApp.Business.MediatR.Queries.GetAllMovie
{
    public class GetAllMovieQueryRequest : IRequest<GetAllMovieQueryResponse>
    {
        public Guid Id { get; set; }
        public PaginationResponse Pagination { get; set; }

    }
}
