using Lab2.Models;
using Lab2.Repositories.Contracts.Common;

namespace Lab2.Repositories.Contracts
{
    public interface IGradeRepository : IGenericRepository<Grade>
    {
        Task<Grade?> GetAsync(int id);
    }
}
