using exerciseBox.Application.Abtraction.Extensions;
using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.Questions.Queries;
using MediatR;

namespace exerciseBox.Application.UseCases.Questions.QueriesHandlers;

public class GetFolderQuestionsHandler : IRequestHandler<GetFolderQuestions, IEnumerable<QuestionDto>>
{
    private readonly IQuestionRepository _questionRepository;

    public GetFolderQuestionsHandler(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }

    public async Task<IEnumerable<QuestionDto>> Handle(GetFolderQuestions request, CancellationToken cancellationToken)
    {
        var questions = await _questionRepository.GetFolderQuestions(request.FolderId);
        return questions.MapToQuestionDto();
    }
}
