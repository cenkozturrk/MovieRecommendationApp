using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationApp.Business.MediatR.Commands
{
    public class CreateMovieCommandRequest : IRequest<CreateMovieCommandResponse>
    {
        public string Name { get; set; }
        public string OverView { get; set; }

    }
}
