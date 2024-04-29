using Lab2.Models;
using Lab2.Repositories.Contracts.Common;

namespace Lab2.Repositories.Contracts
{
    public interface ICourseRepository:IGenericRepository<Course>
    {
        Task<Course?> GetAsync(int id);
    }
}
