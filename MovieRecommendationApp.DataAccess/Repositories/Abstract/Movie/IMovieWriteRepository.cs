using MovieRecommendationApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationApp.DataAccess.Repositories.Abstract
{
    public interface IMovieWriteRepository : IWriteRepository<Movie>
    {
    }
}
