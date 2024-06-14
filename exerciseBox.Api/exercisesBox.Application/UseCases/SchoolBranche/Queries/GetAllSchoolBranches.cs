using exerciseBox.Application.Abtraction.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exerciseBox.Application.UseCases.SchoolBranche.Queries
{
    public class GetAllSchoolBranches : IRequest<IEnumerable<SchoolBrancheDto>>
    {
    }
}
