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
                Id = Guid.Parse(q.id),
                Content = q.content,
                Answer = q.answer,
                DifficultyLevel = q.difficultyLevel,
                SchoolLevel = q.schoolLevel,
                Topic = q.topic,
                Author = q.author,
            });
        }
        public static IEnumerable<Questions> MapToQuestions(this IEnumerable<QuestionDto> questionsDto)
        {
            return questionsDto.Select(q => new Questions
            {
               id = q.Id.ToString(),
                content = q.Content
            });
        }
    }
}
