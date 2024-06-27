using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.Questions.Commands;
using MediatR;

namespace exerciseBox.Application.UseCases.Questions.CommandHandlers;

public class CreateQuestionHandler : IRequestHandler<CreateQuestion, QuestionDto>
{
    private readonly IQuestionRepository _questionRepository;
    private readonly ISchoolBranchesRepository _schoolBranchesRepository;
    private readonly ISchoolTypeRepository _schoolTypeRepository;

    public CreateQuestionHandler(
        IQuestionRepository questionTypesRepository,
        ISchoolBranchesRepository schoolBranchesRepository,
        ISchoolTypeRepository schoolTypeRepository
    )
    {
        _questionRepository = questionTypesRepository;
        _schoolBranchesRepository = schoolBranchesRepository;
        _schoolTypeRepository = schoolTypeRepository;
    }

    public async Task<QuestionDto> Handle(CreateQuestion request, CancellationToken cancellationToken)
    {
        request.Question.SchoolBranch = await _schoolBranchesRepository.ReadIdByTeacher(request.Question.Author);
        request.Question.SchoolType = await _schoolTypeRepository.ReadIdByTeacher(request.Question.Author);

        var question = await _questionRepository.CreateAsync(request.Question);
        if (question == null) {
            throw new Exception("Failed to create question");
        }
        return question;
    }
}
