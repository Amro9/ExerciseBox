using exerciseBox.Application.Abtraction.Models;
using MediatR;

namespace exerciseBox.Application.UseCases.ExerciseSheets.Commands;

/// <summary>
/// Befehl zum Generieren eines neuen Übungsblattes.
/// </summary>
public class GenerateNewExerciseSheet : IRequest<byte[]>
{
    public string[] QuestionIds { get; set; }
    public ExerciseSheetDto ExerciseSheet { get; set; }
    public bool WithSolutions { get; set; }
}
