using Microsoft.EntityFrameworkCore;
using MovieRecommendationApp.Business.MovieRepository.Abstract;
using MovieRecommendationApp.DataAccess.Context;
using MovieRecommendationApp.DataAccess.Repositories;
using MovieRecommendationApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationApp.Business.MovieRepository
{
    public class MovieWriteRepository : WriteRepository<Movie>, IMovieWriteRepository
    {
        public MovieWriteRepository(MovieDbContext context, DbSet<Movie> dbSet) : base(context, dbSet)
        {
        }
    }
}
