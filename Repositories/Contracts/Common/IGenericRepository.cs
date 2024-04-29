using Lab2.Models;
using System.Linq.Expressions;

namespace Lab2.Repositories.Contracts.Common
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        Task InsertAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
