namespace Lab2.Models
{
    public class Tutor
    {
        public int TutorId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public ICollection<CourseTutor> CourseTutors { get; set; } = new List<CourseTutor>();
    }
}
