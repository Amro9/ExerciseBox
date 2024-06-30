using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Domain.Entities;
using exerciseBox.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace exerciseBox.Infrastructur.Repositories
{
    /// <summary>
    /// Implementierung des ISchoolBranchesRepository-Interfaces für die Datenbankoperationen bezüglich Schultypen.
    /// </summary>
    public class SchoolBranchRepository : ISchoolBranchesRepository
    {
        private readonly ExercisesBoxContext _context;

        /// <summary>
        /// Konstruktor der Klasse SchoolBranchRepository.
        /// </summary>
        /// <param name="context"></param>
        public SchoolBranchRepository(ExercisesBoxContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Erstellt eine neue Schule in der Datenbank. (nicht implementiert)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<SchoolBranches> CreateAsync(SchoolBranches entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Löscht eine Schule aus der Datenbank. (nicht implementiert)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<SchoolBranches> DeleteAsync(SchoolBranches entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Liest alle Schulen aus der Datenbank. (nicht implementiert)
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<IEnumerable<SchoolBranches>> ReadAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Liest eine Schule anhand ihrer E-Mail-Adresse aus der Datenbank. (nicht implementiert)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<SchoolBranches> ReadByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Liest alle Schulen einer bestimmten Schule aus der Datenbank.
        /// </summary>
        /// <param name="schoolId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<SchoolBranches>> ReadBySchoolId(string schoolId)
        {
           var branches = _context.SchoolsBranchesJunction.Where(s => s.School == schoolId).Select(s => s.Branch).ToListAsync();
           return await _context.SchoolBranches.Where(s => branches.Result.Contains(s.Id)).ToListAsync();
        }

        public Task<string> ReadIdByTeacher(string teacherId)
        {
            throw new NotImplementedException();
        }

        public async Task<SchoolBranches> UpdateAsync(SchoolBranches entity)
        {
            throw new NotImplementedException();
        }
    }
}
