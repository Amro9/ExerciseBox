using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exerciseBox.Infrastructur.Repositories
{
    public class SchoolLevelRepository : ISchoolLevelRepository
    {
        private readonly ExercisesBoxContext _context;

        public SchoolLevelRepository(ExercisesBoxContext context)
        {
            _context = context;
        }

        public Task<int> CreateAsync(int entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int entity)
        {
            throw new NotImplementedException();
        }
        public Task<int> UpdateAsync(int entity)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<int>> ReadAsync()
        {
            return await _context.SchoolLevels.Select(l => l.Level).ToListAsync();
        }
        public Task<int> ReadByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<int>> ReadByTeacherId(string teacherId)
        {
            try
            {
                return await _context.TeachersSchoolLevelsJunction.Select(l => l.SchoolLevel).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
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
