 using Microsoft.EntityFrameworkCore;
using MovieRecommendationApp.Domain.Common;
using MovieRecommendationApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationApp.DataAccess.Repositories.Abstract
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        //Write ya da Read interfaceleri hangi veri tabanın da çalışırsa çalışsın benim istediğim vermiş olduğum kurallar içerisinde çalışsın.
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(List<T> datas);
        bool Remove(T model);
        bool RemoveRamge(List<T> datas);
        Task<bool> RemoveAsync(string id);
        bool Update(T model);
        Task<int> SaveAsync();

    }
}
