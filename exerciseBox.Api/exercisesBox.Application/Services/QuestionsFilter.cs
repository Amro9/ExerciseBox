using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exerciseBox.Application.Services
{
    /// <summary>
    /// Stellt Methoden zum Filtern von Fragen bereit.
    /// </summary>
    public static class QuestionsFilter
    {
        /// <summary>
        /// Filtert ausgeblendete Fragen aus einer Liste von Fragen.
        /// </summary>
        /// <param name="questions">Die Liste von Fragen, die gefiltert werden soll.</param>
        /// <param name="hiddenQuestions">Die Liste von ausgeblendeten Fragen.</param>
        /// <returns>Eine Liste von Fragen ohne die ausgeblendeten Fragen.</returns>
        public static IEnumerable<QuestionDto> FilterHiddenQuestions(IEnumerable<QuestionDto> questions, IEnumerable<QuestionDto> hiddenQuestions)
        {
            return questions.Where(q => !hiddenQuestions.Any(hq => hq.Id == q.Id));
        }

        /// <summary>
        /// Filtert eine Liste von Fragen basierend auf den angegebenen Suchparametern.
        /// </summary>
        /// <param name="questions">Die Liste von Fragen, die gefiltert werden soll.</param>
        /// <param name="searchParams">Die Suchparameter zur Filterung der Fragen.</param>
        /// <returns>Eine gefilterte Liste von Fragen basierend auf den Suchparametern.</returns>
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
            return questions;
        }
    }
}
