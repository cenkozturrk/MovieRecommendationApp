namespace MovieRecommendationApp.Business.MediatR.Queries.Movie.GetAllMovie
{
    public class GetAllMovieQueryResponse
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}
