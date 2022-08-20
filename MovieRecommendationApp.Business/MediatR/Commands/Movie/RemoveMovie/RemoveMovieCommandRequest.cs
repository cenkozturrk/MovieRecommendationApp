using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationApp.Business.MediatR.Commands.Movie.RemoveMovie
{
    public class RemoveMovieCommandRequest : IRequest<RemoveMovieCommandResponse>
    {
        public string Id { get; set; }
    }
}
