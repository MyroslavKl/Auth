namespace Lab2.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; } = string.Empty;    
        public string Surname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public ICollection<GradeStudent> GradeStudents { get; set; } = new List<GradeStudent>();
    }
}
