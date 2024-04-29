using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2.Models
{
    public class GradeStudent
    {
        public int Id { get; set; }

        public int GradeId { get; set; }
        public int StudentId { get; set; }
        [ForeignKey("GradeId")]
        public Grade Grade { get; set; } = null!;
        [ForeignKey("StudentId")]
        public Student Student { get; set; } = null!;
    }
}
