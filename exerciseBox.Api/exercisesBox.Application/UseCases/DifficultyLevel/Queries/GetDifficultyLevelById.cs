using exerciseBox.Application.Abtraction.Models;
using MediatR;

namespace exerciseBox.Application.UseCases.DifficultyLevel.Queries
{
    public class GetDifficultyLevelById : IRequest<DifficultyLevelDto>
    {
        public string Id { get; set; }
        public GetDifficultyLevelById(string id)
        {

            Id = id;
        }
    }
}
