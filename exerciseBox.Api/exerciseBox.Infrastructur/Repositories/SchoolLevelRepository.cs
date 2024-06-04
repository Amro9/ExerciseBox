using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exerciseBox.Infrastructur.Repositories
{
    public class SchoolLevelRepository : ISchoolLevelRepository
    {
        private readonly ExerciseBoxContext _context;

        public SchoolLevelRepository(ExerciseBoxContext context)
        {
            _context = context;
        }

        public Task<SchoolLevels> Create(SchoolLevels entity)
        {
            throw new NotImplementedException();
        }

        public Task<SchoolLevels> Delete(SchoolLevels entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SchoolLevels>> Read()
        {
            throw new NotImplementedException();
        }

        public Task<SchoolLevels> ReadById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<SchoolLevels> Update(SchoolLevels entity)
        {
            throw new NotImplementedException();
        }
    }
}
