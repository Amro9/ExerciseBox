using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace exerciseBox.Infrastructur.Repositories
{
    /// <summary>
    /// Implementierung des ISchoolLevelRepository-Interfaces für die Datenbankoperationen bezüglich Schulstufen.
    /// </summary>
    public class SchoolLevelRepository : ISchoolLevelRepository
    {
        private readonly ExercisesBoxContext _context;

        public SchoolLevelRepository(ExercisesBoxContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Erstellt eine neue Schulstufe in der Datenbank (nicht implementiert).
        /// 
        public Task<int> CreateAsync(int entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Löscht eine Schulstufe aus der Datenbank (nicht implementiert).
        /// </summary>
        public Task<int> DeleteAsync(int entity)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Aktualisiert eine Schulstufe in der Datenbank (nicht implementiert).
        /// </summary>
        public Task<int> UpdateAsync(int entity)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Liest alle Schulstufen aus der Datenbank.
        /// </summary>
        public async Task<IEnumerable<int>> ReadAsync()
        {
            return await _context.SchoolLevels.Select(l => l.Level).ToListAsync();
        }
        /// <summary>
        /// Liest eine Schulstufe anhand ihrer ID aus der Datenbank (nicht implementiert).
        /// </summary>
        public Task<int> ReadByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Liest alle Schulstufen des Lehrers aus der Datenbank.
        /// </summary>
        public async Task<IEnumerable<int>> ReadByTeacherId(string teacherId)
        {
            try
            {
                return await _context.TeachersSchoolLevelsJunction.Where(s => s.Teacher == teacherId).Select(l => l.SchoolLevel).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Liest alle Schulstufen des Schultyps aus der Datenbank.
        /// </summary>
        public async Task<IEnumerable<int>> ReadBySchoolTypeId(int schoolTypeId)
        {
            try
            {
                return await _context.SchoolTypesLevelsJunction.Where(l => l.SchoolType == schoolTypeId).Select(l => l.SchoolLevel).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
