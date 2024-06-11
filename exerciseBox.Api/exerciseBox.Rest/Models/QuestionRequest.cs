namespace exerciseBox.Rest.Models
{
    public class QuestionRequest
    {
        public string QuestionText { get; set; }
        public string Answer { get; set; }
        public int SchoolLevel { get; set; }
        public string DifficultyLevel { get; set; }
        public string Subject { get; set; }
        public string Topic { get; set; }  
        public bool QuestionOnlyForMe { get; set; }
    }
}
