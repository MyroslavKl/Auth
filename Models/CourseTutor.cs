using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2.Models
{
    public class CourseTutor
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int TutorId { get; set;}

        [ForeignKey("CourseId")]
        public Course Course { get; set; } = null!;
        [ForeignKey(("TutorId"))]
        public Tutor Tutor { get; set; } = null!;
    }
}
