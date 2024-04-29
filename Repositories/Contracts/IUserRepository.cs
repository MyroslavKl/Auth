using Lab2.Models;
using Lab2.Repositories.Contracts.Common;

namespace Lab2.Repositories.Contracts;

public interface IUserRepository:IGenericRepository<User>
{
    public Task<User?> GetAsync(string email);
}