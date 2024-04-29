using Lab2.Data;
using Lab2.Models;
using Lab2.Repositories.Contracts;
using Lab2.Repositories.RepositoryImplementation.Common;
using Microsoft.EntityFrameworkCore;

namespace Lab2.Repositories.RepositoryImplementation;

public class UserRepository:GenericRepository<User>,IUserRepository
{
    private readonly AppDbContext _context;
    public UserRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<User?> GetAsync(string email)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        return user;
    }
}