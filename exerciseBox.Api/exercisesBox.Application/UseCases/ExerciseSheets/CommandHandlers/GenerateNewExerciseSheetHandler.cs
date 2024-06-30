using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.Services.Interface;
using exerciseBox.Application.UseCases.ExerciseSheets.Commands;
using MediatR;

namespace exerciseBox.Application.UseCases.ExerciseSheets.CommandHandlers;

/// <summary>
/// Befehlsbehandlung zum Generieren eines neuen Übungsblattes.
/// </summary>
public class GenerateNewExerciseSheetHandler : IRequestHandler<GenerateNewExerciseSheet, byte[]>
{
    private readonly IExerciseSheetGenerator _exerciseSheetGenerator;
    private readonly IQuestionRepository _questionRepository;

    /// <summary>
    /// Initialisiert eine neue Instanz der <see cref="GenerateNewExerciseSheetHandler"/> Klasse.
    /// </summary>
    /// <param name="exerciseSheetGenerator"></param>
    /// <param name="questionRepository"></param>
    public GenerateNewExerciseSheetHandler(IExerciseSheetGenerator exerciseSheetGenerator, IQuestionRepository questionRepository)
    {
        _exerciseSheetGenerator = exerciseSheetGenerator;
        _questionRepository = questionRepository;
    }

    public async Task<byte[]> Handle(GenerateNewExerciseSheet request, CancellationToken cancellationToken)
    {
        var questions = await _questionRepository.GetAllQuestionsByRangeOfIdsAsync(request.QuestionIds);

        if (questions == null)
            throw new Exception("No questions found");

        var exerciseSheet = _exerciseSheetGenerator.Generate(request.ExerciseSheet, questions, request.WithSolutions);    
        return exerciseSheet;
    }
}
