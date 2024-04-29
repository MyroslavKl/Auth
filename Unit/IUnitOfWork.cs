using Lab2.Repositories.Contracts;

namespace Lab2.Unit
{
    public interface IUnitOfWork:IDisposable
    {
        IStudentRepository StudentRepository { get; }
        ITutorRepository TutorRepository { get; }
        ICourseRepository CourseRepository { get; }
        IGradeRepository GradeRepository { get; }
        IGradeStudentsRepository GradeStudentsRepository { get; }
        ICourseTutorRepository CourseTutorRepository { get; }
        IUserRepository UserRepository { get; }
        IRoleRepository RoleRepository { get; }
        Task Save();
    }
}
