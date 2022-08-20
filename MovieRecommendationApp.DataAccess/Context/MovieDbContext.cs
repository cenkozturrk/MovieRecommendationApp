using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieRecommendationApp.Domain.Common;
using MovieRecommendationApp.Domain.Entities;
using MovieRecommendationApp.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationApp.DataAccess.Context
{
    public class MovieDbContext : IdentityDbContext<AppUser , AppRole, string>
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }


        //Bundan sonra SaveChanges her tetiklendiği anda ben insert ile updated yapılan tüm dataları elde edip üzerlerinde
        //istediğim değişikliği yapıp arından SaveChanges tekrardan devreye sokabiliriz.
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //ChangeTracker entityler üzerinde yapılan değişikliklerin ya da  yeni eklenen verinin yakalanmasını sağlayan propertydir.
            //ChangeTracker neyi yakalar diye sorarsak, Update operasyonların da track edilen verileri yakalayıp elde etmemizi sağlar.


            //Bundan sonra sürece giren tüm BaseEntityleri yakalar ve icerisinde ki datalar getirir.
            //Ne kadar data geliyorsa yakalıyoruz.
            var datas = ChangeTracker
                .Entries<BaseEntity>();
             
            foreach (var data in datas)
            {
                 _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.Now,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.Now,
                    //eger ikisi de degilse asagıdakine git
                    _ => DateTime.Now


                };
            }
                

            return await base.SaveChangesAsync(cancellationToken);

            // 1. olarak override tetiklenir.
            // 2. olarak gelen dataları yakalacayagız
            // 3. fonskyionun icinde ki işlevleri yapıp SaveChangesAsync tekrar cagırıp orada ki değişikliklere göre
            // sql sorgusunu yapılır.
        }
    }
}
