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
    /// Implementierung des ISchoolTypeRepository-Interfaces für die Datenbankoperationen bezüglich Schultypen.
    /// </summary>
    public class SchoolTypeRepository : ISchoolTypeRepository
    {
        private readonly ExercisesBoxContext _context;

        public SchoolTypeRepository(ExercisesBoxContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
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
        /// Liest die ID des Schultyps anhand der Lehrer-ID aus der Datenbank.
        /// </summary>
        /// <param name="teacherId">Die ID des Lehrers.</param>
        /// <returns>Die ID des Schultyps als Ganzzahl.</returns>
        public async Task<int> ReadIdByTeacher(string teacherId)
        {
            var school = await _context.Teachers
                .Where(t => t.Email == teacherId)
                .Select(s => s.School)
                .FirstOrDefaultAsync();

            return await _context.Schools
                .Where(s => s.Email == school)
                .Select(s => s.SchoolType)
                .FirstOrDefaultAsync();
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
