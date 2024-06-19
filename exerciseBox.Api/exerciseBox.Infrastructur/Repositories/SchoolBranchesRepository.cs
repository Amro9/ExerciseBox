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
    public class SchoolBranchesRepository : ISchoolBranchesRepository
    {
        private readonly ExercisesBoxContext _context;
        public SchoolBranchesRepository(ExercisesBoxContext exercisesBoxContext)
        {
            _context = exercisesBoxContext;
        }
        public Task<SchoolBranches> CreateAsync(SchoolBranches entity)
        {
            throw new NotImplementedException();
        }

        public Task<SchoolBranches> DeleteAsync(SchoolBranches entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SchoolBranches>> ReadAsync()
        {
            return await _context.SchoolBranches.ToListAsync();
        }

        public Task<SchoolBranches> ReadByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SchoolBranches> UpdateAsync(SchoolBranches entity)
        {
            throw new NotImplementedException();
        }
    }
}
