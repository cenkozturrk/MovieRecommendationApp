using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationApp.Business.MediatR.Commands.Movie.UpdateMovie
{
    public class UpdateMovieCommandRequest : IRequest<UpdateMovieCommandResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string OriginalLanguage { get; set; }
        public string OriginalTitle { get; set; }
        public string OverView { get; set; }
        public decimal Popularity { get; set; }
        public int VoteCount { get; set; }
    }
}
