using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MusicStore.Database.Entities;
using MusicStore.Services.Contracts;

namespace MusicStore.Services.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T: class
    {

        protected MusicStoreDbContext _context;

        public RepositoryBase(MusicStoreDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        
        public void Create(T entity) => _context.Set<T>().Add(entity);
        
        public void Delete(T entity) => _context.Set<T>().Remove(entity);
        
        public IQueryable<T> GetAll() => _context.Set<T>().AsNoTracking();
        
        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression) => _context.Set<T>().Where(expression).AsNoTracking();
        
        public void Update(T entity) => _context.Set<T>().Update(entity);
        
    }
}
