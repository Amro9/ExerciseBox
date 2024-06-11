
using exerciseBox.Domain.Entities;

namespace exerciseBox.Application.Abtraction.Models
{
    public class QuestionDto
    {
        public Guid Id { get; set; }
        public string Author { get; set; }
        public string QuestionText { get; set; }
        public string Answer { get; set; }
        public int SchoolLevel { get; set; }
        public string DifficultyLevel { get; set; }
        public string Subject { get; set; }
        public string Topic { get; set; }
        public bool QuestionIsPrivate { get; set; }


        public QuestionDto()
        {
                Id = Guid.NewGuid();
        }
        public static implicit operator QuestionDto(Questions question)
        {
            return new QuestionDto
            {
                Id = Guid.Parse(question.Id),
                QuestionText = question.QuestionText,
                Answer = question.Answer,
                DifficultyLevel = question.DifficultyLevel,
                SchoolLevel = question.SchoolLevel,
                Topic = question.Topic,
                QuestionIsPrivate = question.QuestionIsPrivate,
                Author = question.Author
            };
        }

        public static implicit operator Questions(QuestionDto question)
        {
            return new Questions
            {
                Id  = question.Id.ToString(),
                QuestionText = question.QuestionText,
                Answer = question.Answer,
                DifficultyLevel = question.DifficultyLevel,
                SchoolLevel = question.SchoolLevel,
                Topic = question.Topic,
                QuestionIsPrivate = question.QuestionIsPrivate,
                Author = question.Author

            };
        }
    }
}
