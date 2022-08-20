using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationApp.Business.MediatR.Queries.Movie.GetByIdMovie
{
    public class GetByIdMovieQueryRequest : IRequest<GetByIdMovieQueryResponse>
    {
        public string Id { get; set; }
    }
}
