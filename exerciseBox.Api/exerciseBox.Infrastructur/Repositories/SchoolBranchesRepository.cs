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
        public Task<SchoolBranches> Create(SchoolBranches entity)
        {
            throw new NotImplementedException();
        }

        public Task<SchoolBranches> Delete(SchoolBranches entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SchoolBranches>> Read()
        {
            return await _context.SchoolBranches.ToListAsync();
        }

        public Task<SchoolBranches> ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SchoolBranches> Update(SchoolBranches entity)
        {
            throw new NotImplementedException();
        }
    }
}
