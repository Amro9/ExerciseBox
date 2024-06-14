using exerciseBox.Domain.Entities;

namespace exerciseBox.Application.Services.Interface;

public interface IExerciseSheetGenerator
{
    byte[] Generate(ExerciseSheet exerciseSheet, IEnumerable<Questions> questions);
}
