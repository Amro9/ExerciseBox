namespace exerciseBox.Application.Services.Models
{
    public class QuestionSearchParams
    {
        public int? SchoolType { get; set; }
        public string? SchoolBranch { get; set; }
        public int? SchoolLevel { get; set; }
        public string? Subject { get; set; }
        public string? Topic { get; set; }
        public string? DifficultyLevel { get; set; }
    }
}
