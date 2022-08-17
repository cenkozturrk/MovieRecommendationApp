using Microsoft.EntityFrameworkCore;
using MovieRecommendationApp.DataAccess.Context;
using MovieRecommendationApp.DataAccess.Repositories.Abstract;
using MovieRecommendationApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationApp.Business.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly MovieDbContext _context;
        public ReadRepository(MovieDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)
        {
            //Eger tracking istemiyorsan(deger false donuyorsa) querynin AsNoTracking fonksiyonuyla
            //gelecek olan dataların track edilmesini bu sekilde kesiyorsun. Amac, olabilecek maaliyetten kacınmak. 
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }
            

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {         
            //Eger tracking istemiyorsan burda ki querye asnotracking halini gönder.
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }
        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(method);
        }



        //Bu kısım da where T : class yapısını değiştirdik çünkü alt kısım da id'sine gmre sorgualama yapacağım fakat
        //          her biri için ayrı ıd atama yapmadım. Bunun yerine base alacagı sınıfı 
        //          BaseEntity göstererek otomatiken ortak bir idyi hepsine tanımlamış oluyoruz.(İşaretleyici pattern)
        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        //=> await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        {

            //IQueryable ile çalışıyor isek findasync meythodu yoktur. Dolayısıyla marker interfaceyi kullanıyoruz.
            var query = Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        }


    }
}
