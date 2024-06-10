namespace exerciseBox.Rest.Models
{
    public class QuestionModel
    {
        public string QuestionText { get; set; }
        public string Answer { get; set; }
        //public int SelectedLevel { get; set; }
        public string DifficultyLevel { get; set; }
        public string Subject { get; set; }
        public string Topic { get; set; }   
        public string Class { get; set; }
        public bool QuestionOnlyForMe { get; set; }
        public bool QuestionIsSpecific { get; set; }
    }
}
