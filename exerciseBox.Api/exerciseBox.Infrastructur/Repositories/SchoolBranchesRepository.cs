using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Domain.Entities;
using exerciseBox.Infrastructur;
using Microsoft.EntityFrameworkCore;

namespace exerciseBox.Infrastructure.Repositories
{
    /// <summary>
    /// Implementierung des ISchoolBranchesRepository-Interfaces für Datenbankoperationen bezüglich Schulzweige.
    /// </summary>
    public class SchoolBranchesRepository : ISchoolBranchesRepository
    {
        private readonly ExercisesBoxContext _context;

        public SchoolBranchesRepository(ExercisesBoxContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Erstellt einen neuen Schulzweig in der Datenbank (nicht implementiert).
        /// </summary>
        public Task<SchoolBranches> CreateAsync(SchoolBranches entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Löscht einen Schulzweig aus der Datenbank (nicht implementiert).
        /// </summary>
        public Task<SchoolBranches> DeleteAsync(SchoolBranches entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Liest alle Schulzweige aus der Datenbank.
        /// </summary>
        public async Task<IEnumerable<SchoolBranches>> ReadAsync()
        {
            return await _context.SchoolBranches.ToListAsync();
        }

        /// <summary>
        /// Liest einen Schulzweig anhand seiner ID aus der Datenbank (nicht implementiert).
        /// </summary>
        public Task<SchoolBranches> ReadByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Liest alle Schulzweige einer Schule aus der Datenbank.
        /// </summary>
        /// <param name="schoolId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<SchoolBranches>> ReadBySchoolId(string schoolId)
        {
            return await _context.SchoolsBranchesJunction
                .Where(sb => sb.School == schoolId)
                .Include(sb => sb.BranchNavigation)
                .Select(sb => sb.BranchNavigation)
                .ToListAsync();
        }

        public async Task<string> ReadIdByTeacher(string teacherId)
        {
            var school = await _context.Teachers.Where(t => t.Email == teacherId).Select(t => t.School).FirstOrDefaultAsync();
            return await _context.SchoolsBranchesJunction.Where(sb => sb.School == school).Select(sb => sb.Branch).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Aktualisiert einen Schulzweig in der Datenbank (nicht implementiert).
        /// </summary>
        public Task<SchoolBranches> UpdateAsync(SchoolBranches entity)
        {
            throw new NotImplementedException();
        }
    }
}
