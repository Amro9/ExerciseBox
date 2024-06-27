using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exerciseBox.Application.Services
{
    public static class QuestionsFilter
    {
        public static IEnumerable<QuestionDto> FilterHiddenQuestions(IEnumerable<QuestionDto> questions,IEnumerable<QuestionDto> hiddenQuestions)
        {
            return questions.Where(q => !hiddenQuestions.Any(hq => hq.Id == q.Id));
        }
        public static IEnumerable<QuestionDto> Filter(IEnumerable<QuestionDto> questions, QuestionSearchParams searchParams)
        {
            if (searchParams.SchoolType != 0)
            {
                questions = questions.Where(q => q.SchoolType == searchParams.SchoolType);
            }
            if (!string.IsNullOrEmpty(searchParams.SchoolBranch))
            {
                questions = questions.Where(q => q.SchoolBranch == searchParams.SchoolBranch);
            }
            if (searchParams.SchoolLevel != 0)
            {
                questions = questions.Where(q => q.SchoolLevel == searchParams.SchoolLevel);
            }
            if (!string.IsNullOrEmpty(searchParams.Topic))
            {
                questions = questions.Where(q => q.Topic == searchParams.Topic);
            }
            if (!string.IsNullOrEmpty(searchParams.DifficultyLevel))
            {
                questions = questions.Where(q => q.DifficultyLevelDto.Id == searchParams.DifficultyLevel);
            }
            if (!string.IsNullOrEmpty(searchParams.Subject))
            {
                // hier dachte i
            }

            return questions;
        }
    }
}
