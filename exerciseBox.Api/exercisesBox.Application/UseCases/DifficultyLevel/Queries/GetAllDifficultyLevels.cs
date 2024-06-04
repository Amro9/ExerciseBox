using exerciseBox.Application.Abtraction.Models;
using MediatR;

namespace exerciseBox.Application.UseCases.DifficultyLevel.Queries
{
    public class GetAllDifficultyLevels : IRequest<IEnumerable<DifficultyLevelDto>>
    {
    }
}
