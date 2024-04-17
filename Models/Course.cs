namespace AcademyWebProject.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public float Price { get; set; }
        public string Instructor { get; set; } = string.Empty;
        public decimal Rating { get; set; }
        public string Image { get; set; } = string.Empty;
    }
}