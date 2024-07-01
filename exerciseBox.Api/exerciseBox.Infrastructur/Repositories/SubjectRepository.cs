using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Domain.Entities;
using exerciseBox.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace exerciseBox.Infrastructur.Repositories
{
    /// <summary>
    /// Implementierung des ISubjectRepository-Interfaces für die Datenbankoperationen bezüglich Schulfächern.
    /// </summary>
    internal class SubjectRepository : ISubjectRepository
    {
        private readonly ExercisesBoxContext _context;

        public SubjectRepository(ExercisesBoxContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Erstellt ein neues Schulfach in der Datenbank (nicht implementiert).
        /// </summary>
        public Task<Subjects> CreateAsync(Subjects entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Löscht ein Schulfach in der Datenbank (nicht implementiert).
        /// </summary>
        public Task<Subjects> DeleteAsync(Subjects entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Liest alle Schulfächer aus der Datenbank.
        /// </summary>
        public async Task<IEnumerable<Subjects>> ReadAsync()
        {
            return await _context.Subjects.ToListAsync();
        }

        /// <summary>
        /// Liest ein Schulfach anhand seiner ID aus der Datenbank.
        /// </summary>
        public async Task<Subjects> ReadByIdAsync(Guid id)
        {
            return await _context.Subjects.FindAsync(id);
        }

        /// <summary>
        /// Liest ein Schulfach anhand eines Themas aus der Datenbank.
        /// </summary>
        public async Task<Subjects> ReadByTopic(string id)
        {
            var topic = await _context.Topics
                .Where(t => t.Id == id)
                .Include(t => t.SubjectNavigation) // Inkludiert die Navigationseigenschaft zum zugehörigen Fach
                .FirstOrDefaultAsync();

            if (topic == null || topic.SubjectNavigation == null)
                return null;

            return topic.SubjectNavigation;
        }

        /// <summary>
        /// Aktualisiert ein Schulfach in der Datenbank (nicht implementiert).
        /// </summary>
        public Task<Subjects> UpdateAsync(Subjects entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Liest alle Schulfächer, die einem bestimmten Lehrer zugeordnet sind, aus der Datenbank.
        /// </summary>
        public async Task<IEnumerable<Subjects>> GetSubjectsByTeacherId(string id)
        {
            var subjectIds = await _context.TeachersSubjectsJunction
                .Where(x => x.Teacher == id)
                .Select(x => x.Subject)
                .ToListAsync();

            return await _context.Subjects
                .Where(x => subjectIds.Contains(x.Id))
                .ToListAsync();
        }

        /// <summary>
        /// Liest alle Schulfächer, die einer bestimmten Schule zugeordnet sind, aus der Datenbank.
        /// </summary>
        public async Task<IEnumerable<Subjects>> GetSubjectsBySchoolId(string id)
        {
            var subjectIds = await _context.SchoolsSubjectsJunction
                .Where(x => x.School == id)
                .Select(x => x.Subject)
                .ToListAsync();

            return await _context.Subjects
                .Where(x => subjectIds.Contains(x.Id))
                .ToListAsync();
        }

        /// <summary>
        /// Liest alle Schulfächer, die einem bestimmten Schulzweig zugeordnet sind, aus der Datenbank.
        /// </summary>
        public async Task<IEnumerable<Subjects>> GetSubjectsBySchoolBranchId(string id)
        {
            return await _context.BranchesSubjectsJunction
                .Where(x => x.Branch == id)
                .Select(x => x.SubjectNavigation)
                .ToListAsync();
        }
    }
}
