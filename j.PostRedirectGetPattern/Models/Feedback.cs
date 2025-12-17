namespace j.PostRedirectGetPattern.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Comment { get; set; }
    }
}