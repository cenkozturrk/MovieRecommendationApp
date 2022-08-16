using Microsoft.EntityFrameworkCore;
using MovieRecommendationApp.Business.MovieRepository.Abstract;
using MovieRecommendationApp.DataAccess.Context;
using MovieRecommendationApp.DataAccess.Repositories.Abstract;
using MovieRecommendationApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationApp.Business.MovieRepository
{
    public class MovieReadRepository : ReadRepository<Movie>, IMovieReadRepository
    {
        public MovieReadRepository(MovieDbContext context, DbSet<Movie> dbSet) : base(context, dbSet)
        {
        }
    }
}
