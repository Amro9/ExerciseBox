using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace exerciseBox.Infrastructur.Repositories
{
    /// <summary>
    /// Implementierung des ISchoolTypeRepository-Interfaces für die Datenbankoperationen bezüglich Schultypen.
    /// </summary>
    public class SchoolTypeRepository : ISchoolTypeRepository
    {
        private readonly ExercisesBoxContext _context;

        public SchoolTypeRepository(ExercisesBoxContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Erstellt einen neuen Schultyp in der Datenbank (nicht implementiert).
        /// </summary>
        public Task<SchoolTypes> CreateAsync(SchoolTypes entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Löscht einen Schultyp aus der Datenbank (nicht implementiert).
        /// </summary>
        public Task<SchoolTypes> DeleteAsync(SchoolTypes entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Liest alle Schultypen aus der Datenbank.
        /// </summary>
        public async Task<IEnumerable<SchoolTypes>> ReadAsync()
        {
            return await _context.SchoolTypes.ToListAsync();
        }

        /// <summary>
        /// Liest einen Schultyp anhand seiner ID aus der Datenbank (nicht implementiert).
        /// </summary>
        public Task<SchoolTypes> ReadByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Aktualisiert einen Schultyp in der Datenbank (nicht implementiert).
        /// </summary>
        public Task<SchoolTypes> UpdateAsync(SchoolTypes entity)
        {
            throw new NotImplementedException();
        }
    }
}
