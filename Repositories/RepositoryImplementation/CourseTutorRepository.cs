using Lab2.Data;
using Lab2.Models;
using Lab2.Repositories.Contracts;
using Lab2.Repositories.RepositoryImplementation.Common;

namespace Lab2.Repositories.RepositoryImplementation
{
    public class CourseTutorRepository : GenericRepository<CourseTutor>, ICourseTutorRepository
    {
        public CourseTutorRepository(AppDbContext context) : base(context)
        {
        }
    }
}
