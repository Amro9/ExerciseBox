using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Domain.Entities;

namespace exerciseBox.Application.Abtraction.Extensions
{
    public static class QuestionMappingExtension
    {
        public static IEnumerable<QuestionDto> MapToQuestionDto(this IEnumerable<Questions> questions)
        {
            return questions.Select(q => new QuestionDto
            {
                Id = Guid.Parse(q.Id),
                QuestionText = q.QuestionText,
                Answer = q.Answer,
                DifficultyLevel = q.DifficultyLevel,
                SchoolLevel = q.SchoolLevel,
                Topic = q.Topic,
                QuestionIsPrivate = q.QuestionIsPrivate,
                Author = q.Author,
                Subject = q.TopicNavigation.Subject
            });
        }
        public static IEnumerable<Questions> MapToQuestions(this IEnumerable<QuestionDto> questionsDto)
        {
            return questionsDto.Select(q => new Questions
            {
               Id = q.Id.ToString(),
                QuestionText = q.QuestionText,
                Answer = q.Answer,
                DifficultyLevel = q.DifficultyLevel,
                SchoolLevel = q.SchoolLevel,
                Topic = q.Topic,
                   QuestionIsPrivate = q.QuestionIsPrivate,
                   Author = q.Author
            });
        }
    }
}
