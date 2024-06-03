namespace exerciseBox.Rest.Models
{
    public class QuestionModel
    {
        public string Subject { get; set; }
        public string Topic { get; set; }   
        public string Class { get; set; }
        public string QuestionText { get; set; }
        public string QuestionNote { get; set; }
        public string Answer { get; set; }
        public string AnswerNote { get; set; }
        public string DifficultyLevel { get; set; }
        public bool QuestionOnlyForMe { get; set; }
        public bool QuestionIsSpecific { get; set; }
    }
}
