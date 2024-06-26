using exerciseBox.Application.Services.Interface;
using exerciseBox.Application.UseCases.ExerciseSheets.Commands;
using exerciseBox.Rest.Controllers.RequestModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace exerciseBox.Rest.Controllers
{
    /// <summary>
    /// Controller für Übungsblätter.
    /// </summary>
    public class ExerciseSheetController : BaseController
    {
        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="ExerciseSheetController"/> Klasse.
        /// </summary>
        /// <param name="mediator">Der MediatR-Mediator.</param>
        public ExerciseSheetController(IMediator mediator) : base(mediator) { }

        /// <summary>
        /// Erstellt ein neues Übungsblatt basierend auf den gegebenen Daten.
        /// </summary>
        /// <param name="newExerciseSheet">Die Anfrage zum Erstellen des Übungsblatts.</param>
        /// <returns>Eine <see cref="IActionResult"/> Rückgabe mit dem generierten PDF-Übungsblatt.</returns>
        [HttpPost("GetNewExerciseSheet")]
        public async Task<IActionResult> GetNewExerciseSheet(NewExerciseSheetRequest newExerciseSheet)
        {
            var result = await _mediator.Send(new GenerateNewExerciseSheet
            {
                ExerciseSheet = newExerciseSheet.ExerciseSheet,
                QuestionIds = newExerciseSheet.QuestionIds
            });
            return File(result, "application/pdf", "example.pdf");
        }
    }
}
