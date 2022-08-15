using Microsoft.EntityFrameworkCore;
using MovieRecommendationApp.DataAccess.Context;
using MovieRecommendationApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationApp.DataAccess.Repositories.Abstract
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly MovieDbContext _context;

        public ReadRepository(MovieDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => throw new NotImplementedException();

        public IQueryable<T> GetAll()
         => Table;
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
        => Table.Where(method);

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
     => await Table.FirstOrDefaultAsync(method);
       



        //Bu kısım da where T : class yapısını değiştirdik çünkü alt kısım da id'sine gmre sorgualama yapacağım fakat
        //          her biri için ayrı ıd atama yapmadım. Bunun yerine base alacagı sınıfı 
        //          BaseEntity göstererek otomatiken ortak bir idyi hepsine tanımlamış oluyoruz.(İşaretleyici pattern)
        public async Task<T> GetByIdAsync(string id)
       => await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));

    }
}
