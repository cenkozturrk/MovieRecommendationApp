using MediatR;
using MovieRecommendationApp.DataAccess.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
  
namespace MovieRecommendationApp.Business.MediatR.Commands.Movie.RemoveMovie
{
    public class RemoveMovieCommandHandler : IRequestHandler<RemoveMovieCommandRequest, RemoveMovieCommandResponse>
    {
        readonly IMovieWriteRepository _movieWriteRepository;

        public RemoveMovieCommandHandler(IMovieWriteRepository movieWriteRepository)
        {
            _movieWriteRepository = movieWriteRepository;
        }

        public async Task<RemoveMovieCommandResponse> Handle(RemoveMovieCommandRequest request, CancellationToken cancellationToken)
        {
            await _movieWriteRepository.RemoveAsync(request.Id);
            await _movieWriteRepository.SaveAsync();
            return new();
        }
    }
}
