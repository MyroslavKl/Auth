using Lab2.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab2.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Tutor> Tutors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<CourseTutor> CourseTutors { get; set; }
        public DbSet<GradeStudent> GradeStudents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseTutor>()
                   .HasKey(ba => new { ba.CourseId, ba.TutorId });

            modelBuilder.Entity<CourseTutor>()
                .HasOne(ba => ba.Course)
                .WithMany(b => b.CourseTutors)
                .HasForeignKey(ba => ba.CourseId);

            modelBuilder.Entity<CourseTutor>()
                .HasOne(ba => ba.Tutor)
                .WithMany(a => a.CourseTutors)
                .HasForeignKey(ba => ba.TutorId);

            modelBuilder.Entity<GradeStudent>()
             .HasKey(ba => new { ba.GradeId, ba.StudentId });

            modelBuilder.Entity<GradeStudent>()
                .HasOne(ba => ba.Grade)
                .WithMany(b => b.GradeStudents)
                .HasForeignKey(ba => ba.GradeId);

            modelBuilder.Entity<GradeStudent>()
                .HasOne(ba => ba.Student)
                .WithMany(a => a.GradeStudents)
                .HasForeignKey(ba => ba.StudentId);
            
            modelBuilder.Entity<Role>().HasData([
                new Role {RoleId = 1, RoleName = Lab2.Enum.Role.Teacher.ToString()},
                new Role {RoleId = 2, RoleName = Lab2.Enum.Role.Admin.ToString()},
                new Role{RoleId = 3,RoleName = Lab2.Enum.Role.Student.ToString()}
            ]);

        }
        

    }
}
