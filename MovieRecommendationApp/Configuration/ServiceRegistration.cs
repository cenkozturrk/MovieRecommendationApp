using MovieRecommendationApp.Business.Repositories;
using MovieRecommendationApp.DataAccess.Repositories.Abstract;
using MovieRecommendationApp.Domain.Entities.Identity;

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
            }, ServiceLifetime.Singleton);

            services.AddIdentity<AppUser, AppRole>(options =>
            {
                //Test asamasın da zorlanmamak amaclı kapattım cogunu.
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;

            }).AddEntityFrameworkStores<MovieDbContext>();

            services.AddScoped<IMovieReadRepository, MovieReadRepository>();
            services.AddScoped<IMovieWriteRepository, MovieWriteRepository>();
        }
    }
}
