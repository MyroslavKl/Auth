namespace Lab2.Models
{
    public class Grade
    {
        public int GradeId { get; set; }
        public double Value { get; set; }
        public ICollection<GradeStudent> GradeStudents { get; set; } = new List<GradeStudent>();

    }
}
