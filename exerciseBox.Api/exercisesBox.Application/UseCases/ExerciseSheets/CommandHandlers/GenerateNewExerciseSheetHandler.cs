using exerciseBox.Application.Services.Interface;
using exerciseBox.Application.UseCases.ExerciseSheets.Commands;
using MediatR;

namespace exerciseBox.Application.UseCases.ExerciseSheets.CommandHandlers;

public class GenerateNewExerciseSheetHandler : IRequestHandler<GenerateNewExerciseSheet, byte[]>
{
    private readonly IExerciseSheetGenerator _exerciseSheetGenerator;

    public GenerateNewExerciseSheetHandler(IExerciseSheetGenerator exerciseSheetGenerator)
    {
        _exerciseSheetGenerator = exerciseSheetGenerator;
    }

    public async Task<byte[]> Handle(GenerateNewExerciseSheet request, CancellationToken cancellationToken)
    {
        var exerciseSheet = _exerciseSheetGenerator.Generate();    
        return exerciseSheet;
    }
}
