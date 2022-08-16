using Microsoft.EntityFrameworkCore.Design;

namespace MovieRecommendationApp.Api.Configuration
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MovieDbContext>
    {
        public MovieDbContext CreateDbContext(string[] args)
        {          

            //context nesnesini ayağa kaldırdığımız yer.
            DbContextOptionsBuilder<MovieDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer(Configurations.ConnectingString);
            return new MovieDbContext(dbContextOptionsBuilder.Options);
        }
    }
}
