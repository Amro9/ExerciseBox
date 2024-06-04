using exerciseBox.Application.Abtraction.Extensions;
using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.DifficultyLevel.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exerciseBox.Application.UseCases.DifficultyLevel.QueriesHandlers
{
    public class GetAlleDifficultyLevelsHandler : IRequestHandler<GetAllDifficultyLevels, IEnumerable<DifficultyLevelDto>>
    {
        private readonly IDifficultyLevelRepository _difficultyLevelRepository;
        public GetAlleDifficultyLevelsHandler(IDifficultyLevelRepository difficultyLevelRepository)
        {
            _difficultyLevelRepository = difficultyLevelRepository;
        }
        public async Task<IEnumerable<DifficultyLevelDto>> Handle(GetAllDifficultyLevels request, CancellationToken cancellationToken)
        {
            var difficultyLevels = await _difficultyLevelRepository.Read();
            return difficultyLevels.MapToDifficultyLevelDto();
        }
    }
}
