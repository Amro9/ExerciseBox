using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.Questions.Commands;
using MediatR;

namespace exerciseBox.Application.UseCases.Questions.CommandHandlers;

public class CreateQuestionHandler : IRequestHandler<CreateQuestion, QuestionDto>
{
    private readonly IQuestionRepository _questionRepository;
    private readonly ITeacherRepository _teacherRepository;
    private readonly ISchoolTypeRepository _schoolTypeRepository;
    private readonly ISchoolBranchesRepository _schoolBranchesRepository;

    public CreateQuestionHandler(
        IQuestionRepository questionTypesRepository,
        ISchoolTypeRepository schoolTypeRepository,
        ITeacherRepository teacherRepository
        , 
        ISchoolBranchesRepository schoolBranchesRepository
    )
    {
        _questionRepository = questionTypesRepository;
        _schoolTypeRepository = schoolTypeRepository;
        _teacherRepository = teacherRepository;
        _schoolBranchesRepository = schoolBranchesRepository;
    }

    public async Task<QuestionDto> Handle(CreateQuestion request, CancellationToken cancellationToken)
    {
        var branche = await _teacherRepository.GetTeachersSchoolBranch(request.Question.Author);  
        var branch = await _schoolBranchesRepository.ReadIdByTeacher(request.Question.Author);
        request.Question.SchoolBranch = branche.Id;
        request.Question.SchoolType = await _schoolTypeRepository.ReadIdByTeacher(request.Question.Author);

        var question = await _questionRepository.CreateAsync(request.Question);
        if (question == null)
        {
            throw new Exception("failed to create question");
        }
        return question;
    }
}
