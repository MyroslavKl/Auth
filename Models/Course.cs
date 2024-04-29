using System.ComponentModel.DataAnnotations;

namespace Lab2.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required,MaxLength(25)]
        public string CourseName { get; set; } = string.Empty;
        public ICollection<CourseTutor> CourseTutors { get; set; } = new List<CourseTutor>();

    }
}
