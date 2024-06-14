using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exerciseBox.Application.Abtraction.Extensions
{
    public class SchoolBranchesMappingExtension
    {
        public static IEnumerable<SchoolBrancheDto> MapToDto(IEnumerable<SchoolBranches> schoolBranches)
        {
            return schoolBranches.Select(schoolBranch => (SchoolBrancheDto)schoolBranch);
        }

        public static IEnumerable<SchoolBranches> MapToEntity(IEnumerable<SchoolBrancheDto> schoolBranches)
        {
            return schoolBranches.Select(schoolBranch => (SchoolBranches)schoolBranch);
        }
    }
}
