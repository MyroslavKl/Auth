using Lab2.Data;
using Lab2.Models;
using Lab2.Repositories.Contracts;
using Lab2.Repositories.RepositoryImplementation.Common;
using Microsoft.EntityFrameworkCore;

namespace Lab2.Repositories.RepositoryImplementation
{
    public class StudentRepository: GenericRepository<Student>, IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Student?> GetAsync(int id)
        {
            var grades = await _context.Students
                .Include(b => b.GradeStudents)
                .ThenInclude(ba => ba.Grade)
                .FirstOrDefaultAsync(b => b.StudentId == id);
            return grades;
        }
    }
}
