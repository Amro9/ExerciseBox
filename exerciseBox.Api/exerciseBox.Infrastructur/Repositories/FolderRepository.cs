using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace exerciseBox.Infrastructure.Repositories
{
    /// <summary>
    /// Implementierung des IFolderRepository-Interfaces für Datenbankoperationen bezüglich Ordner.
    /// </summary>
    public class FolderRepository : IFolderRepository
    {
        private readonly ExercisesBoxContext _context;

        public FolderRepository(ExercisesBoxContext exercisesBoxContext)
        {
            _context = exercisesBoxContext;
        }

        /// <summary>
        /// Erstellt einen neuen Ordner in der Datenbank (nicht implementiert).
        /// </summary>
        public async Task<Folders> CreateAsync(Folders entity)
        {
            var folder = await _context.Folders.AddAsync(entity);
            await _context.SaveChangesAsync();
            return folder.Entity;
        }

        /// <summary>
        /// Löscht einen Ordner aus der Datenbank (nicht implementiert).
        /// </summary>
        public Task<Folders> DeleteAsync(Folders entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Liest alle Ordner eines Lehrers aus der Datenbank.
        /// </summary>
        public async Task<IEnumerable<Folders>> GetFoldersByTeacherId(string id)
        {
            return await _context.Folders
                .Where(f => f.Teacher == id)
                .Include(f => f.TopicNavigation)
                .ThenInclude(t => t.SubjectNavigation)
                .ToListAsync();
        }

        /// <summary>
        /// Liest alle Ordner aus der Datenbank (nicht implementiert).
        /// </summary>
        public Task<IEnumerable<Folders>> ReadAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Liest einen Ordner anhand seiner ID aus der Datenbank (nicht implementiert).
        /// </summary>
        public Task<Folders> ReadByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Aktualisiert einen Ordner in der Datenbank (nicht implementiert).
        /// </summary>
        public Task<Folders> UpdateAsync(Folders entity)
        {
            throw new NotImplementedException();
        }
    }
}
