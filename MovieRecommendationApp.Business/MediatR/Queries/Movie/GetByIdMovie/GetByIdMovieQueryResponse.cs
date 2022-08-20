using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationApp.Business.MediatR.Queries.Movie.GetByIdMovie
{
    public class GetByIdMovieQueryResponse
    {
        //public string Message { get; set; } = "Successful...";
        //public bool IsValid { get; set; } = true;
        
        public string Name { get; set; }
        public string OriginalLanguage { get; set; }      
        public string OriginalTitle { get; set; }      
        public string OverView { get; set; }   
        public decimal Popularity { get; set; } 
        public int VoteCount { get; set; }
    }
}
