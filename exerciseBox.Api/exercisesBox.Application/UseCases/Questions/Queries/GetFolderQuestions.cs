using exerciseBox.Application.Abtraction.Models;
using MediatR;

namespace exerciseBox.Application.UseCases.Questions.Queries;

public class GetFolderQuestions : IRequest<IEnumerable<QuestionDto>>
{
    public string FolderId { get; set; }
}
