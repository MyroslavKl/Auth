using Lab2.Data;
using Lab2.Models;
using Lab2.Repositories.Contracts;
using Lab2.Repositories.RepositoryImplementation.Common;

namespace Lab2.Repositories.RepositoryImplementation
{
    public class GradeStudentsRepository : GenericRepository<GradeStudent>, IGradeStudentsRepository
    {
        public GradeStudentsRepository(AppDbContext context) : base(context)
        {
        }
    }
}
