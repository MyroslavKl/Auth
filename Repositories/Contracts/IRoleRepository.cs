using Lab2.Models;
using Lab2.Repositories.Contracts.Common;

namespace Lab2.Repositories.Contracts
{
    public interface IRoleRepository:IGenericRepository<Role>
    {
        Role GetAsync(int id);
    }
}
