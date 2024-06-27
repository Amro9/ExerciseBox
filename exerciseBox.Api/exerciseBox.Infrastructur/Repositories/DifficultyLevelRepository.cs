using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Domain.Entities;
using exerciseBox.Infrastructur;
using Microsoft.EntityFrameworkCore;

namespace exerciseBox.Infrastructure.Repositories
{
    /// <summary>
    /// Implementierung des IDifficultyLevelRepository-Interfaces für Datenbankoperationen bezüglich Schwierigkeitslevel von Fragen.
    /// </summary>
    internal class DifficultyLevelRepository : IDifficultyLevelRepository
    {
        private readonly ExercisesBoxContext _context;

        public DifficultyLevelRepository(ExercisesBoxContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Erstellt ein neues Schwierigkeitslevel in der Datenbank (nicht implementiert).
        /// </summary>
        public Task<QuestionDifficultyLevels> CreateAsync(QuestionDifficultyLevels entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Löscht ein Schwierigkeitslevel aus der Datenbank (nicht implementiert).
        /// </summary>
        public Task<QuestionDifficultyLevels> DeleteAsync(QuestionDifficultyLevels entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Liest alle Schwierigkeitslevel aus der Datenbank.
        /// </summary>
        public async Task<IEnumerable<QuestionDifficultyLevels>> ReadAsync()
        {
            return await _context.QuestionDifficultyLevels.ToListAsync();
        }

        /// <summary>
        /// Liest ein Schwierigkeitslevel anhand seiner ID aus der Datenbank (nicht implementiert).
        /// </summary>
        public Task<QuestionDifficultyLevels> ReadByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Aktualisiert ein Schwierigkeitslevel in der Datenbank (nicht implementiert).
        /// </summary>
        public Task<QuestionDifficultyLevels> UpdateAsync(QuestionDifficultyLevels entity)
        {
            throw new NotImplementedException();
        }
    }
}
