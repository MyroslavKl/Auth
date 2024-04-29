using Lab2.Models;
using Lab2.Repositories.Contracts.Common;

namespace Lab2.Repositories.Contracts
{
    public interface ITutorRepository:IGenericRepository<Tutor>
    {
        public Task<Tutor?> GetAsync(int id);

    }
}
