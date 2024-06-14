using exerciseBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exerciseBox.Application.Abtraction.Repositories
{
    public interface ISchoolBranchesRepository : IRepository<SchoolBranches, int>
    {
    }
}
