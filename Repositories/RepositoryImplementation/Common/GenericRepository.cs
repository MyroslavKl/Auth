using Lab2.Data;
using Lab2.Models;
using Lab2.Repositories.Contracts.Common;
using Microsoft.EntityFrameworkCore;

namespace Lab2.Repositories.RepositoryImplementation.Common
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<TEntity> _dbSet;


        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            IQueryable<TEntity> query = _dbSet;
            return query;
        }


        public async Task InsertAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

    }
}
