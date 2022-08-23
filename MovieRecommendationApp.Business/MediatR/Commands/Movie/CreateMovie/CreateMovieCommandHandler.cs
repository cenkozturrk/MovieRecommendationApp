using MediatR;
using Microsoft.Extensions.Logging;
using MovieRecommendationApp.DataAccess.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationApp.Business.MediatR.Commands.Movie.CreateMovie
{
    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommandRequest, CreateMovieCommandResponse>
    {
        readonly IMovieWriteRepository _movieWriteRepository;
        readonly ILogger<IMovieWriteRepository> _logger;


        public CreateMovieCommandHandler(IMovieWriteRepository movieWriteRepository,
            ILogger<IMovieWriteRepository> logger)
        {
            _movieWriteRepository = movieWriteRepository;
            _logger = logger;
        }

        public async Task<CreateMovieCommandResponse> Handle(CreateMovieCommandRequest request, CancellationToken cancellationToken)
        {
            await _movieWriteRepository.AddAsync(new()
            {
                Name = request.Name,
                OverView = request.OverView,

            });
            _logger.LogInformation(" Created... ");
            await _movieWriteRepository.SaveAsync();
            return new();
        }
    }
}
