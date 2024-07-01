using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.Services.Interface;
using exerciseBox.Application.UseCases.ExerciseSheets.Commands;
using MediatR;

namespace exerciseBox.Application.UseCases.ExerciseSheets.CommandHandlers
{
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
        /// <param name="exerciseSheetGenerator">Der Service zum Generieren von Übungsblättern.</param>
        /// <param name="questionRepository">Das Repository für Fragen.</param>
        public GenerateNewExerciseSheetHandler(IExerciseSheetGenerator exerciseSheetGenerator, IQuestionRepository questionRepository)
        {
            _exerciseSheetGenerator = exerciseSheetGenerator ?? throw new ArgumentNullException(nameof(exerciseSheetGenerator));
            _questionRepository = questionRepository ?? throw new ArgumentNullException(nameof(questionRepository));
        }

        /// <summary>
        /// Führt die Behandlung des Befehls zum Generieren eines neuen Übungsblattes aus.
        /// </summary>
        /// <param name="request">Der Befehl zum Generieren eines neuen Übungsblattes.</param>
        /// <param name="cancellationToken">Das Token zur Abbruchsteuerung.</param>
        /// <returns>Ein Byte-Array, das das generierte Übungsblatt darstellt.</returns>
        public async Task<byte[]> Handle(GenerateNewExerciseSheet request, CancellationToken cancellationToken)
        {
            var questions = await _questionRepository.GetAllQuestionsByRangeOfIdsAsync(request.QuestionIds);

            if (questions == null || questions.Count() == 0)
                throw new Exception("Keine Fragen gefunden.");

            var exerciseSheet = _exerciseSheetGenerator.Generate(request.ExerciseSheet, questions, request.WithSolutions);
            return exerciseSheet;
        }
    }
}
