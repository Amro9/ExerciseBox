using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.Questions.Commands;
using MediatR;

namespace exerciseBox.Application.UseCases.Questions.CommandHandlers;

public class CreateQuestionHandler : IRequestHandler<CreateQuestion, QuestionDto>
{
    private readonly IQuestionRepository _questionRepository;

    public CreateQuestionHandler(IQuestionRepository questionTypesRepository)
    {
        _questionRepository = questionTypesRepository;
    }

    public async Task<QuestionDto> Handle(CreateQuestion request, CancellationToken cancellationToken)
    {
        var question = await _questionRepository.CreateAsync(request.Question);
        if (question == null) {
            throw new Exception("Failed to create question");
        }
        return question;
    }
}
