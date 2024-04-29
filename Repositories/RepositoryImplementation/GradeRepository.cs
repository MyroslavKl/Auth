using Lab2.Data;
using Lab2.Models;
using Lab2.Repositories.Contracts;
using Lab2.Repositories.RepositoryImplementation.Common;
using Microsoft.EntityFrameworkCore;

namespace Lab2.Repositories.RepositoryImplementation
{
    public class GradeRepository:GenericRepository<Grade>,IGradeRepository
    {
        private readonly AppDbContext _context;

        public GradeRepository(AppDbContext context):base(context)
        {
            _context = context;
        }

        public async Task<Grade?> GetAsync(int id)
        {
            var students = await _context.Grades
                .Include(b => b.GradeStudents)
                .ThenInclude(ba => ba.Student)
                .FirstOrDefaultAsync(b => b.GradeId == id);

            return students;
        }
    }
}
