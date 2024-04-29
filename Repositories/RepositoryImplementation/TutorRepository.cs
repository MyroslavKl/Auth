using Lab2.Data;
using Lab2.Models;
using Lab2.Repositories.Contracts;
using Lab2.Repositories.RepositoryImplementation.Common;
using Microsoft.EntityFrameworkCore;

namespace Lab2.Repositories.RepositoryImplementation
{
    public class TutorRepository:GenericRepository<Tutor>,ITutorRepository
    {
        private readonly AppDbContext _context;

        public TutorRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Tutor?> GetAsync(int id)
        {
            var courses = await _context.Tutors
             .Include(b => b.CourseTutors)
              .ThenInclude(ba => ba.Course)
              .FirstOrDefaultAsync(b => b.TutorId == id);

            return courses;

        }
    }
}
