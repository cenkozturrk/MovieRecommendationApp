using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MovieRecommendationApp.DataAccess.Context;
using MovieRecommendationApp.DataAccess.Repositories.Abstract;
using MovieRecommendationApp.Domain.Common;
using MovieRecommendationApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationApp.DataAccess.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        readonly private MovieDbContext _context;
        private DbSet<T> _dbSet;
        public WriteRepository(MovieDbContext context, DbSet<T> dbSet)
        {
            _context = context;
            _dbSet = _context.Set<T>(); 
        }

        public DbSet<T> Table => _context.Set<T>();

        public void Add(T entity)
        {
           _dbSet.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
           _dbSet.AddRange(entities);
        }
        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Remove(int id)
        {
            _dbSet.Remove(GetById(id));
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);            
        }
        public async Task<int> SaveAsync()
           => await _context.SaveChangesAsync();

    }
}
