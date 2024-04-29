using Lab2.Data;
using Lab2.Models;
using Lab2.Repositories.Contracts;
using Lab2.Repositories.RepositoryImplementation.Common;
using Microsoft.EntityFrameworkCore;

namespace Lab2.Repositories.RepositoryImplementation
{
    public class CourseRepository:GenericRepository<Course>,ICourseRepository
    {
        private readonly AppDbContext _context;

        public CourseRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Course?> GetAsync(int id)
        {
            var tutors = await _context.Courses
            .Include(b => b.CourseTutors)
             .ThenInclude(ba => ba.Tutor)
          .FirstOrDefaultAsync(b => b.CourseId == id);

            return tutors;
        }
    }
}
