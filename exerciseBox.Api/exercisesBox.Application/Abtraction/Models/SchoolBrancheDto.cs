using exerciseBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exerciseBox.Application.Abtraction.Models
{
    public class SchoolBrancheDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public static implicit operator SchoolBrancheDto(SchoolBranches schoolBranche)
        {
            if (schoolBranche is null)
                return null;

            return new SchoolBrancheDto
            {
                Id = Guid.Parse(schoolBranche.Id),
                Name = schoolBranche.Name
            };
        }
        public static implicit operator SchoolBranches(SchoolBrancheDto schoolBranche)
        {
            if (schoolBranche is null)
                return null;

            return new SchoolBranches
            {
                Id = schoolBranche.Id.ToString(),
                Name = schoolBranche.Name
            };
        }

    }
}
