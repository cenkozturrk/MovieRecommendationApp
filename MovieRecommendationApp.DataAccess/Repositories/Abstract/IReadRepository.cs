using Microsoft.EntityFrameworkCore;
using MovieRecommendationApp.Domain.Common;
using MovieRecommendationApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationApp.DataAccess.Repositories.Abstract
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        //Normal şartlar da bu işlemleri ORM araçlar yapabiliyor fakat amaç daha customize bir query yollamak.
        //Default sekilde giden tracking mekanizmasını bozmak için tracking = true mekanizmasını kullandık.
        IQueryable<T> GetAll(bool tracking = true);

        //Ozel tanımlı fonfsiyona verilen dogru olan datalar sorgulanıp getirilsin.(Where şartı gibi kullandık.)
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true);

        //Tekil bir nesneyi getiricek olan sorgu getirilsin.
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true);
        Task<T> GetByIdAsync(string id, bool tracking = true);
    }
}
