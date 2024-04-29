using Lab2.Models;
using Lab2.Repositories.Contracts.Common;
using Lab2.Repositories.Contracts.Common;

namespace Lab2.Repositories.Contracts
{
    public interface IStudentRepository:IGenericRepository<Student>
    {
        public Task<Student?> GetAsync(int id);
    }
}
