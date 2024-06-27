using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exerciseBox.Infrastructur.Repositories
{
    /// <summary>
    /// Implementierung des ITopicRepository-Interfaces für die Datenbankoperationen bezüglich Themen.
    /// </summary>
    public class TopicRepository : ITopicRepository
    {
        private readonly ExercisesBoxContext _context;

        public TopicRepository(ExercisesBoxContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Erstellt ein neues Thema (nicht implementiert).
        /// </summary>
        public Task<Topics> CreateAsync(Topics entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Löscht ein Thema (nicht implementiert).
        /// </summary>
        public Task<Topics> DeleteAsync(Topics entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Liest alle Themen aus der Datenbank.
        /// </summary>
        public async Task<IEnumerable<Topics>> ReadAsync()
        {
            return await _context.Topics.ToListAsync();
        }

        /// <summary>
        /// Liest alle Themen eines bestimmten Fachs aus der Datenbank.
        /// </summary>
        public async Task<IEnumerable<Topics>> ReadBySubject(string subject)
        {
            return await _context.Topics
                .Where(t => t.Subject == subject)
                .Include(t => t.SubjectNavigation) // Inkludiert die Navigationseigenschaft zu dem zugehörigen Fach
                .ToListAsync();
        }

        /// <summary>
        /// Liest ein Thema anhand seiner ID aus der Datenbank (nicht implementiert).
        /// </summary>
        public Task<Topics> ReadByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Aktualisiert ein Thema (nicht implementiert).
        /// </summary>
        public Task<Topics> UpdateAsync(Topics entity)
        {
            throw new NotImplementedException();
        }
    }
}
