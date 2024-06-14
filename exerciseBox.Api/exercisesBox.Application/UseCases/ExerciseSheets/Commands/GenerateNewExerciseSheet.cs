using exerciseBox.Application.Abtraction.Models;
using MediatR;

namespace exerciseBox.Application.UseCases.ExerciseSheets.Commands;

public class GenerateNewExerciseSheet : IRequest<byte[]>
{
    public string[] QuestionIds { get; set; }
    public ExerciseSheetDto ExerciseSheet { get; set; }
}
