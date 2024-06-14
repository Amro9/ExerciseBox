using exerciseBox.Application.Abtraction.Extensions;
using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.SchoolBranche.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exerciseBox.Application.UseCases.SchoolBranche.QueriesHandlers
{
    public class GetAllSchoolBranchesHandler : IRequestHandler<GetAllSchoolBranches, IEnumerable<SchoolBrancheDto>>
    {
        private readonly ISchoolBranchesRepository _schoolBranchesRepository;

        public GetAllSchoolBranchesHandler(ISchoolBranchesRepository schoolBranchesRepository)
        {
            _schoolBranchesRepository = schoolBranchesRepository;
        }
        public async Task<IEnumerable<SchoolBrancheDto>> Handle(GetAllSchoolBranches request, CancellationToken cancellationToken)
        {
            var schoolBranches =await _schoolBranchesRepository.Read();
            return SchoolBranchesMappingExtension.MapToDto(schoolBranches);

        }
    }
}
