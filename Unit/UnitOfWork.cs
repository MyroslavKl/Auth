using Lab2.Data;
using Lab2.Repositories.Contracts;
using Lab2.Repositories.RepositoryImplementation;

namespace Lab2.Unit
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IStudentRepository _studentRepository;
        private ITutorRepository _tutorRepository;
        private ICourseRepository _courseRepository;
        private IGradeRepository _gradeRepository;
        private IGradeStudentsRepository _gradeStudentsRepository;
        private ICourseTutorRepository _courseTutorRepository;
        private IUserRepository _userRepository;
        private IRoleRepository _roleRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IStudentRepository StudentRepository
        {
            get
            {
                if (_studentRepository == null)
                    _studentRepository = new StudentRepository(_context);
                return _studentRepository;
            }
        }

        public ITutorRepository TutorRepository
        {
            get
            {
                if (_tutorRepository == null)
                    _tutorRepository = new TutorRepository(_context);
                return _tutorRepository;
            }
        }

        public ICourseRepository CourseRepository {
            get
            {
                if (_courseRepository == null)
                    _courseRepository = new CourseRepository(_context);
                return _courseRepository;
            }
        }


        public IGradeRepository GradeRepository
        {
            get
            {
                if (_gradeRepository == null)
                    _gradeRepository = new GradeRepository(_context);
                return _gradeRepository;
            }
        }

        public IGradeStudentsRepository GradeStudentsRepository {
            get
            {
                if (_gradeStudentsRepository == null)
                    _gradeStudentsRepository = new GradeStudentsRepository(_context);
                return _gradeStudentsRepository;
            }
        }

        public ICourseTutorRepository CourseTutorRepository {
            get
            {
                if (_courseTutorRepository == null)
                    _courseTutorRepository = new CourseTutorRepository(_context);
                return _courseTutorRepository;
            }
        }

        public IUserRepository UserRepository {
            get
            {
                if (_userRepository == null) { 
                    _userRepository = new UserRepository(_context);
                }
                return _userRepository;
            }
        }

        public IRoleRepository RoleRepository {
            get {
                if (_roleRepository == null) {
                    _roleRepository = new RoleRepository(_context);
                }
                return _roleRepository; 
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
