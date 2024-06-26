using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace exerciseBox.Infrastructure.Repositories
{
    /// <summary>
    /// Implementierung des IQuestionRepository-Interfaces für Datenbankoperationen bezüglich Fragen.
    /// </summary>
    public class QuestionRepository : IQuestionRepository
    {
        private readonly ExercisesBoxContext _context;

        public QuestionRepository(ExercisesBoxContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Erstellt eine neue Frage in der Datenbank.
        /// </summary>
        public async Task<Questions> CreateAsync(Questions entity)
        {
            await _context.Questions.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Speichert eine Frage in einem Ordner.
        /// </summary>
        public async Task<int> SaveQuestionToFolder(string junctionId, string folderId, string questionId)
        {
            try
            {
                _context.Add(new FoldersQuestionsJunction { Id = junctionId, Folder = folderId, Question = questionId });
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
        /// Löscht eine Frage aus der Datenbank (nicht implementiert).
        /// </summary>
        public Task<Questions> DeleteAsync(Questions entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Ruft alle Fragen anhand einer Liste von Frage-IDs aus der Datenbank ab.
        /// </summary>
        public async Task<IEnumerable<Questions>> GetAllQuestionsByRangeOfIdsAsync(string[] questionIds)
        {
            return await _context.Questions.Where(q => questionIds.Contains(q.Id.ToString())).ToListAsync();
        }

        /// <summary>
        /// Ruft alle Fragen eines Ordners aus der Datenbank ab.
        /// </summary>
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
        public async Task<IEnumerable<Questions>> ReadAsync()
        {
            return await _context.Questions.Where(q => q.QuestionIsPrivate == false).Include(q => q.DifficultyLevelNavigation).ToListAsync();
        }

        /// <summary>
        /// Ruft alle Fragen eines bestimmten Themas aus der Datenbank ab.
        /// </summary>
        public async Task<IEnumerable<Questions>> GetQuestionsBySubject(string subjectId)
        {
            var questions = await _context.Questions
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
                .Where(qts => qts.Subject.Id == subjectId)
                .Select(qts => qts.Question)
                .ToListAsync();

            return questions;
        }

        public async Task<bool> HideQuestion(string teacherId, string questionId)
        {
            try { 
            var questionToHide = new TeachersHiddenQuestions
            {
                TeacherId = teacherId,
                QuestionId = questionId,
            };
            _context.TeachersHiddenQuestions.Add(questionToHide);
            _context.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<bool> IsQuestionHidden(string teacherId, string questionId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Liest eine Frage anhand ihrer ID aus der Datenbank (nicht implementiert).
        /// </summary>
        public Task<Questions> ReadByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Aktualisiert eine Frage in der Datenbank (nicht implementiert).
        /// </summary>
        public Task<Questions> UpdateAsync(Questions entity)
        {
            throw new NotImplementedException();
        }

    }
}
