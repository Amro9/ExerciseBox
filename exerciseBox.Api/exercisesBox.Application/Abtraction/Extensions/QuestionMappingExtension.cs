﻿using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace exerciseBox.Application.Abtraction.Extensions
{
    /// <summary>
    /// Erweiterungsmethoden für die Zuordnung von Fragen zwischen der Domäne (DB) und den DTOs.
    /// </summary>
    public static class QuestionMappingExtension
    {
        /// <summary>
        /// Mappt eine Sammlung von <see cref="Questions"/> zu einer Sammlung von <see cref="QuestionDto"/>.
        /// </summary>
        /// <param name="questions">Die Sammlung der <see cref="Questions"/>.</param>
        /// <returns>Eine Sammlung von <see cref="QuestionDto"/>.</returns>
        public static IEnumerable<QuestionDto> MapToQuestionDto(this IEnumerable<Questions> questions)
        {
            if (questions == null)
            {
                return null;
            }
            return questions.Select(q => (QuestionDto)q);
        }

        /// <summary>
        /// Mappt eine Sammlung von <see cref="QuestionDto"/> zu einer Sammlung von <see cref="Questions"/>.
        /// </summary>
        /// <param name="questionsDto">Die Sammlung der <see cref="QuestionDto"/>.</param>
        /// <returns>Eine Sammlung von <see cref="Questions"/>.</returns>
        public static IEnumerable<Questions> MapToQuestions(this IEnumerable<QuestionDto> questionsDto)
        {
            return questionsDto.Select(q => new Questions
            {
                Id = q.Id.ToString(),
                QuestionText = q.QuestionText,
                Answer = q.Answer,
                DifficultyLevel = q.DifficultyLevelDto.Id,
                SchoolLevel = q.SchoolLevel,
                Topic = q.Topic,
                QuestionIsPrivate = q.QuestionIsPrivate,
                Author = q.Author,
                SchoolBranch = q.SchoolBranch,
                SchoolType = q.SchoolType
            });
        }
    }
}
