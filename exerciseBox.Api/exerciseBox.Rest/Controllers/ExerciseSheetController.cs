using exerciseBox.Application.Services.Interface;
using exerciseBox.Application.UseCases.ExerciseSheets.Commands;
using exerciseBox.Rest.Controllers.RequestModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace exerciseBox.Rest.Controllers
{
    public class ExerciseSheetController : BaseController
    {
        public ExerciseSheetController(IMediator mediator, ISessionCommunicator sessionCommunicator) : base(mediator, sessionCommunicator) { }

        [HttpPost("GetNewExercise")]
        public async Task<IActionResult> GetNewExerciseSheet(NewExerciseSheetRequest newExerciseSheet)
        {
            var result = await _mediator.Send(new GenerateNewExerciseSheet { ExerciseSheet = newExerciseSheet.ExerciseSheet, QuestionIds = newExerciseSheet.QuestionIds });
            return File(result, "application/pdf", "example.pdf");
        }
    }
}
