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
        public Task<SchoolLevels> ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<int>> ReadByTeacherId(string teacherId)
        {
            try
            {
                return _context.TeachersSchoolLevelsJunctions.Select(l => l.SchoolLevel).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<SchoolLevels> Update(SchoolLevels entity)
        {
            throw new NotImplementedException();
        }
    }
}
