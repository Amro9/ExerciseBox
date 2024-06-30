using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.Schools.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exerciseBox.Application.UseCases.Schools.QueryHandlers
{
    public class GetBranchesOfSchoolHandler : IRequestHandler<GetBranchesOfSchool, IEnumerable<SchoolBrancheDto>>
    {
        private readonly ISchoolBranchesRepository _schoolBranchesRepository;

        public GetBranchesOfSchoolHandler(ISchoolBranchesRepository schoolBranchesRepository)
        {
            _schoolBranchesRepository = schoolBranchesRepository;
        }

        public async Task<IEnumerable<SchoolBrancheDto>> Handle(GetBranchesOfSchool request, CancellationToken cancellationToken)
        {
            var branches = await _schoolBranchesRepository.ReadBySchoolId(request.SchoolId);
            return branches.Select(b => (SchoolBrancheDto)b);
        }
    }
}
