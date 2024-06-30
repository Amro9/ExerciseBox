using exerciseBox.Domain.Entities;

namespace exerciseBox.Application.Services.Interface
{
    /// <summary>
    /// Schnittstelle für den Exercise Sheet Generator.
    /// </summary>
    public interface IExerciseSheetGenerator
    {
        /// <summary>
        /// Generiert ein Übungsblatt basierend auf dem gegebenen Übungsblatt und einer Sammlung von Fragen.
        /// </summary>
        /// <param name="exerciseSheet">Das Übungsblatt, das generiert werden soll.</param>
        /// <param name="questions">Die Sammlung von Fragen, die in das Übungsblatt aufgenommen werden sollen.</param>
        /// <returns>Ein Byte-Array, das das generierte Übungsblatt repräsentiert.</returns>
        byte[] Generate(ExerciseSheets exerciseSheet, IEnumerable<Questions> questions, bool WithAnswers);
    }
}
