using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            _context = context;
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
        public async Task<Subjects> ReadByTopic(string id)
        {
            
           
            var topic = await _context.Topics
                .Where(t => t.Id == id)
                .Include(t => t.SubjectNavigation) // Inkludiert die Navigationseigenschaft zu dem zugehörigen Fach
                .FirstOrDefaultAsync();
            Console.WriteLine(topic);
               var subject = await _context.Subjects.Where(s => s.Id == topic.Subject)
                .FirstOrDefaultAsync();
            return subject;
        }

        /// <summary>
        /// Liest ein Schulfach anhand seiner ID aus der Datenbank (nicht implementiert).
        /// </summary>
        public async Task<Subjects> ReadByIdAsync(Guid id)
        {
            return await _context.Subjects.FindAsync(id);
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
            // Zuerst werden die IDs der Schulfächer abgerufen, die dem gegebenen Lehrer zugeordnet sind
            var subjectIds = await _context.TeachersSubjectsJunction
                .Where(x => x.Teacher == id)
                .Select(x => x.Subject)
                .ToListAsync();

            // Anschließend werden die Schulfächer aus der Datenbank abgerufen, deren IDs in der Liste subjectIds enthalten sind
            return await _context.Subjects
                .Where(x => subjectIds.Contains(x.Id))
                .ToListAsync();
        }

        /// <summary>
        /// Liest alle Schulfächer, die einer bestimmten Schule zugeordnet sind, aus der Datenbank.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
    }
}
