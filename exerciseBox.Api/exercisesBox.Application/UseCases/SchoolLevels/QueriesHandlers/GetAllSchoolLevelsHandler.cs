using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.SchoolLevels.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exerciseBox.Application.UseCases.SchoolLevels.QueriesHandlers
{
    public class GetAllSchoolLevelsHandler : IRequestHandler<GetAllSchoolLevels, IEnumerable<int>>
    {
        private readonly ISchoolLevelRepository _schoolLevelRepository;
        public GetAllSchoolLevelsHandler(ISchoolLevelRepository schoolLevelRepository)
        {
            _schoolLevelRepository = schoolLevelRepository;    
        }

        public async Task<IEnumerable<int>> Handle(GetAllSchoolLevels request, CancellationToken cancellationToken)
        {
            return await _schoolLevelRepository.ReadAsync();
        }
    }
}
