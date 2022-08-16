using MovieRecommendationApp.Business.Repositories;
using MovieRecommendationApp.DataAccess.Repositories.Abstract;

namespace MovieRecommendationApp.Api.Configuration
{
    public static class ServiceRegistration
    {
        public static void AddServices(this IServiceCollection services)
        {            
            services.AddDbContext<MovieDbContext>(options =>
            {
                options.UseSqlServer(Configurations.ConnectingString);
                //options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IMovieReadRepository, MovieReadRepository>();
            services.AddScoped<IMovieWriteRepository, MovieWriteRepository>();
        }
    }
}
