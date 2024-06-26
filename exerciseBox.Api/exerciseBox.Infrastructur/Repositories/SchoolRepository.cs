using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace exerciseBox.Infrastructur.Repositories
{
    /// <summary>
    /// Implementierung des ISchoolRepository-Interfaces für die Datenbankoperationen bezüglich Schulen.
    /// </summary>
    public class SchoolRepository : ISchoolRepository
    {
        private readonly ExercisesBoxContext _context;

        public SchoolRepository(ExercisesBoxContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Erstellt eine neue Schule in der Datenbank.
        /// </summary>
        public async Task<Schools> CreateAsync(Schools entity)
        {
            await _context.Schools.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Löscht eine Schule aus der Datenbank.
        /// </summary>
        public async Task<Schools> DeleteAsync(Schools entity)
        {
            _context.Schools.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Liest alle Schulen aus der Datenbank.
        /// </summary>
        public async Task<IEnumerable<Schools>> ReadAsync()
        {
            return await _context.Schools.Include(x => x.SchoolTypeNavigation).ToListAsync();
        }

        /// <summary>
        /// Liest eine Schule anhand ihrer E-Mail-Adresse aus der Datenbank.
        /// </summary>
        public async Task<Schools> ReadByEmail(string email)
        {
            return await _context.Schools.Include(x => x.SchoolTypeNavigation).FirstOrDefaultAsync(x => x.Email == email);
        }

        /// <summary>
        /// Liest eine Schule anhand ihrer ID aus der Datenbank.
        /// </summary>
        public async Task<Schools> ReadByIdAsync(string id)
        {
            return await _context.Schools.Include(x => x.SchoolTypeNavigation).FirstOrDefaultAsync(x => x.Email == id.ToString());
        }

        /// <summary>
        /// Aktualisiert eine Schule in der Datenbank (nicht implementiert).
        /// </summary>
        public async Task<Schools> UpdateAsync(Schools entity)
        {
            throw new NotImplementedException();
        }
    }
}
