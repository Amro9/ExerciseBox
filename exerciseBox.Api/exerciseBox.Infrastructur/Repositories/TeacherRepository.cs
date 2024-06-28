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
    /// Implementierung des ITeacherRepository-Interfaces für die Datenbankoperationen bezüglich Lehrer.
    /// </summary>
    public class TeacherRepository : ITeacherRepository
    {
        private readonly ExercisesBoxContext _context;

        public TeacherRepository(ExercisesBoxContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Erstellt einen neuen Lehrer in der Datenbank.
        /// </summary>
        public async Task<Teachers> CreateAsync(Teachers entity)
        {
            var teacher = await _context.Teachers.AddAsync(entity);
            await _context.SaveChangesAsync();
            return teacher.Entity;
        }


        public async Task DeactivateTeacher(string teacherId)
        {
            await _context.Teachers.Where(t => t.Email == teacherId).ForEachAsync(t => t.IsActive = false);
            await _context.SaveChangesAsync();
        }

        public async Task ActivateTeacher(string teacherId)
        {
            await _context.Teachers.Where(t => t.Email == teacherId).ForEachAsync(t => t.IsActive = true);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Löscht einen Lehrer (nicht implementiert).
        /// </summary>
        public Task<Teachers> DeleteAsync(Teachers entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Liest alle Lehrer aus der Datenbank und schließt die Navigationseigenschaften zu Schule und Schultyp ein.
        /// </summary>
        public async Task<IEnumerable<Teachers>> ReadAsync()
        {
            return await _context.Teachers
                .Include(t => t.SchoolNavigation) // Schließt die Navigationseigenschaft zur Schule ein
                    .ThenInclude(s => s.SchoolTypeNavigation) // Schließt die Navigationseigenschaft zum Schultyp der Schule ein
                .ToListAsync();
        }

        /// <summary>
        /// Liest einen Lehrer anhand seiner E-Mail-Adresse aus der Datenbank und schließt die Navigationseigenschaften zu Schule und Schultyp ein.
        /// </summary>
        public async Task<Teachers> ReadByEmailAsync(string email)
        {
            return await _context.Teachers
                .Include(t => t.SchoolNavigation) // Schließt die Navigationseigenschaft zur Schule ein
                    .ThenInclude(s => s.SchoolTypeNavigation) // Schließt die Navigationseigenschaft zum Schultyp der Schule ein
                .FirstOrDefaultAsync(t => t.Email == email);
        }

        /// <summary>
        /// Liest einen Lehrer anhand seiner ID aus der Datenbank (nicht implementiert).
        /// </summary>
        public Task<Teachers> ReadByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Liest alle Lehrer einer bestimmten Schule aus der Datenbank.
        /// </summary>
        public async Task<IEnumerable<Teachers>> ReadBySchoolIdAsync(string schoolId)
        {
            return await _context.Teachers
                .Where(t => t.School == schoolId)
                .ToListAsync();
        }

        /// <summary>
        /// Aktualisiert einen Lehrer (nicht implementiert).
        /// </summary>
        public async Task<Teachers> UpdateAsync(Teachers entity)
        {
            var teacher = _context.Teachers.FirstOrDefault(t => t.Email == entity.Email);
            teacher.Surname = entity.Surname;
            teacher.FamilyName = entity.FamilyName;
            teacher.IsActive = entity.IsActive;
            teacher.Email = entity.Email;
            var updatedTeacher = await _context.SaveChangesAsync();
            return teacher;
        }

        /// <summary>
        /// Fügt einem Lehrer die angegebenen Fächer hinzu.
        /// </summary>
        /// <param name="teacherId"></param>
        /// <param name="subjectIds"></param>
        /// <returns></returns>
        public async Task AddSubject(string teacherId, string subjectId)
        {
            await _context.TeachersSubjectsJunction.AddAsync(new TeachersSubjectsJunction
            {
                Id = Guid.NewGuid().ToString(),
                Teacher = teacherId,
                Subject = subjectId
            });
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Entfernt das gegebene Fach von einem Lehrer.
        /// </summary>
        /// <param name="teacherId"></param>
        /// <param name="subjectId"></param>
        /// <returns></returns>
        public async Task RemoveSubject(string teacherId, string subjectId)
        {
            var subject = await _context.TeachersSubjectsJunction.FirstOrDefaultAsync(ts => ts.Teacher == teacherId && ts.Subject == subjectId);
            _context.TeachersSubjectsJunction.Remove(subject);
            await _context.SaveChangesAsync();
        }

        public Task AddSubjects(string teacherId, string[] subjectIds)
        {
            throw new NotImplementedException();
        }
    }
}
