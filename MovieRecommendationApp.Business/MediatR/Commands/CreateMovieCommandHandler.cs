using MediatR;
using MovieRecommendationApp.DataAccess.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationApp.Business.MediatR.Commands
{
    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommandRequest, CreateMovieCommandResponse>
    {
        readonly IMovieWriteRepository _movieWriteRepository;

        public CreateMovieCommandHandler(IMovieWriteRepository movieWriteRepository)
        {
            _movieWriteRepository = movieWriteRepository;
        }

        public async Task<CreateMovieCommandResponse> Handle(CreateMovieCommandRequest request, CancellationToken cancellationToken)
        {
            await _movieWriteRepository.AddAsync(new()
            {
                Name = request.Name,
                OverView = request.OverView,

            });
            await _movieWriteRepository.SaveAsync();
            return new();
        }
    }
}
