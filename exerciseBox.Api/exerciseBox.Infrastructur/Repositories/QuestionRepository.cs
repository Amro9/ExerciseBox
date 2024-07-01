using Azure.Core;
using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Domain.Entities;
using exerciseBox.Infrastructur;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace exerciseBox.Infrastructure.Repositories
{
    /// <summary>
    /// Implementierung des IQuestionRepository-Interfaces für Datenbankoperationen bezüglich Fragen.
    /// </summary>
    public class QuestionRepository : IQuestionRepository
    {
        private readonly ExercisesBoxContext _context;

        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="QuestionRepository"/> Klasse.
        /// </summary>
        /// <param name="context">Der Datenbankkontext für Übungskasten.</param>
        public QuestionRepository(ExercisesBoxContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Erstellt eine neue Frage in der Datenbank.
        /// </summary>
        /// <param name="entity">Die Frage, die erstellt werden soll.</param>
        /// <returns>Die erstellte Frage als <see cref="Questions"/>.</returns>
        public async Task<Questions> CreateAsync(Questions entity)
        {
            await _context.Questions.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Speichert eine Frage in einem Ordner.
        /// </summary>
        /// <param name="junctionId">Die ID der Verbindung.</param>
        /// <param name="folderId">Die ID des Ordners.</param>
        /// <param name="questionId">Die ID der Frage.</param>
        /// <returns>Ein Task, der die abgeschlossene Operation anzeigt.</returns>
        public async Task<int> SaveQuestionToFolder(string junctionId, string folderId, string questionId)
        {
            try
            {
                _context.Add(new FoldersQuestionsJunction { Folder = folderId, Question = questionId });
                await _context.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Speichern der Frage im Ordner: {ex.Message}");
                return 0;
            }
        }

        /// <summary>
        /// Entfernt eine Frage aus einem Ordner.
        /// </summary>
        /// <param name="folderId">Die ID des Ordners.</param>
        /// <param name="questionId">Die ID der Frage.</param>
        /// <returns>Ein Task, der die abgeschlossene Operation anzeigt.</returns>
        public async Task<int> RemoveQuestionFromFolder(string folderId, string questionId)
        {
            var folderQuestion = await _context.FoldersQuestionsJunction
                    .FirstOrDefaultAsync(fq => fq.Folder == folderId && fq.Question == questionId);

            if (folderQuestion != null)
            {
                _context.FoldersQuestionsJunction.Remove(folderQuestion);
                return await _context.SaveChangesAsync();
            }
            return 0;
        }

        /// <summary>
        /// Ruft alle Fragen anhand einer Liste von Frage-IDs aus der Datenbank ab.
        /// </summary>
        /// <param name="questionIds">Die Liste der Frage-IDs.</param>
        /// <returns>Eine Liste von Fragen als <see cref="IEnumerable{Questions}"/>.</returns>
        public async Task<IEnumerable<Questions>> GetAllQuestionsByRangeOfIdsAsync(string[] questionIds)
        {
            return await _context.Questions.Where(q => questionIds.Contains(q.Id.ToString())).ToListAsync();
        }

        /// <summary>
        /// Ruft alle Fragen eines Ordners aus der Datenbank ab.
        /// </summary>
        /// <param name="folderId">Die ID des Ordners.</param>
        /// <returns>Eine Liste von Fragen als <see cref="IEnumerable{Questions}"/>.</returns>
        public async Task<IEnumerable<Questions>> GetFolderQuestions(string folderId)
        {
            var questionIds = await _context.FoldersQuestionsJunction
                .Where(fq => fq.Folder == folderId)
                .Select(fq => fq.Question)
                .ToListAsync();

            return await _context.Questions
                .Where(q => questionIds.Contains(q.Id.ToString()))
                .Include(q => q.TopicNavigation)
                .Include(q => q.DifficultyLevelNavigation)
                .ToListAsync();
        }

        /// <summary>
        /// Liest alle öffentlichen Fragen aus der Datenbank.
        /// </summary>
        /// <returns>Eine Liste von Fragen als <see cref="IEnumerable{Questions}"/>.</returns>
        public async Task<IEnumerable<Questions>> ReadAsync()
        {
            return await _context.Questions.Where(q => q.QuestionIsPrivate == false).Include(q => q.DifficultyLevelNavigation).ToListAsync();
        }

        /// <summary>
        /// Ruft alle Fragen eines bestimmten Themas aus der Datenbank ab.
        /// </summary>
        /// <param name="subjectId">Die ID des Themas.</param>
        /// <returns>Eine Liste von Fragen als <see cref="IEnumerable{Questions}"/>.</returns>
        public async Task<IEnumerable<Questions>> GetQuestionsBySubject(string subjectId)
        {
            var questions = await _context.Questions
                .Include(q => q.DifficultyLevelNavigation)
                .Join(
                    _context.Topics,
                    q => q.Topic,
                    t => t.Id,
                    (q, t) => new { Question = q, Topic = t })
                .Join(
                    _context.Subjects,
                    qt => qt.Topic.Subject,
                    s => s.Id,
                    (qt, s) => new { qt.Question, qt.Topic, Subject = s })
                .Where(qts => qts.Subject.Id == subjectId && qts.Question.QuestionIsPrivate == false)
                .Select(qts => qts.Question)
                .ToListAsync();

            return questions;
        }

        /// <summary>
        /// Versteckt eine Frage für einen Lehrer in der Datenbank.
        /// </summary>
        /// <param name="id">Die ID des zu versteckenden Datensatzes.</param>
        /// <param name="teacherId">Die ID des Lehrers.</param>
        /// <param name="questionId">Die ID der Frage.</param>
        /// <returns>Ein Task, der angibt, ob die Operation erfolgreich war.</returns>
        public async Task<bool> HideQuestion(string id, string teacherId, string questionId)
        {
            try
            {
                var questionToHide = new TeachersHiddenQuestions
                {
                    Id = id,
                    TeacherId = teacherId,
                    QuestionId = questionId,
                };
                _context.TeachersHiddenQuestions.Add(questionToHide);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Ruft alle versteckten Fragen eines Lehrers aus der Datenbank ab.
        /// </summary>
        /// <param name="teacherId">Die ID des Lehrers.</param>
        /// <returns>Eine Liste von Fragen als <see cref="IEnumerable{Questions}"/>.</returns>
        public async Task<IEnumerable<Questions>> GetHiddenQuestionsByTeacher(string teacherId)
        {
            var hiddenQuestions = await _context.TeachersHiddenQuestions
                .Where(q => q.TeacherId == teacherId)
                .Select(q => q.QuestionId)
                .ToListAsync();

            return await _context.Questions
                .Where(q => hiddenQuestions.Contains(q.Id.ToString()))
                .ToListAsync();
        }

        // Die folgenden Methoden sind nicht implementiert und werfen eine NotImplementedException.

        /// <summary>
        /// Liest eine Frage anhand ihrer ID aus der Datenbank (nicht implementiert).
        /// </summary>
        /// <param name="id">Die ID der Frage.</param>
        /// <returns>Ein Task, der die abgeschlossene Operation anzeigt.</returns>
        public Task<Questions> ReadByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Aktualisiert eine Frage in der Datenbank (nicht implementiert).
        /// </summary>
        /// <param name="entity">Die Frage, die aktualisiert werden soll.</param>
        /// <returns>Ein Task, der die abgeschlossene Operation anzeigt.</returns>
        public Task<Questions> UpdateAsync(Questions entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Löscht eine Frage aus der Datenbank (nicht implementiert).
        /// </summary>
        /// <param name="entity">Die Frage, die gelöscht werden soll.</param>
        /// <returns>Ein Task, der die abgeschlossene Operation anzeigt.</returns>
        public Task<Questions> DeleteAsync(Questions entity)
        {
            throw new NotImplementedException();
        }
    }
}
