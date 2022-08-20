using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationApp.Business.MediatR.Commands.Movie.RemoveMovie
{
    public class RemoveMovieCommandHandler : IRequestHandler<RemoveMovieCommandRequest, RemoveMovieCommandResponse>
    {
        public async Task<RemoveMovieCommandResponse> Handle(RemoveMovieCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
