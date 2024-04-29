using Lab2.Data;
using Lab2.Models;
using Lab2.Repositories.Contracts;
using Lab2.Repositories.RepositoryImplementation.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace Lab2.Repositories.RepositoryImplementation
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        private readonly AppDbContext _context;

        public RoleRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Role GetAsync(int id)
        {
            var role = _context.Roles.FirstOrDefault(x => x.RoleId == id);
            return role;
        }
    }
}
