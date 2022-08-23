using MediatR;
using Microsoft.Extensions.Logging;
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
        readonly ILogger<IMovieWriteRepository> _logger;

        public RemoveMovieCommandHandler(IMovieWriteRepository movieWriteRepository,
            ILogger<IMovieWriteRepository> logger)
        {
            _movieWriteRepository = movieWriteRepository;
            _logger = logger;
        }

        public async Task<RemoveMovieCommandResponse> Handle(RemoveMovieCommandRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(" Deleted... ");
            await _movieWriteRepository.RemoveAsync(request.Id);
            await _movieWriteRepository.SaveAsync();
            return new();
        }
    }
}
