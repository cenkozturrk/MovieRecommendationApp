using MovieRecommendationApp.DataAccess.Repositories.Abstract;
using MovieRecommendationApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationApp.Business.MovieRepository.Abstract
{
    public interface IMovieWriteRepository : IWriteRepository<Movie>
    {
    }
}
