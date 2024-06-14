using exerciseBox.Application.Services.Interface;
using exerciseBox.Application.UseCases.ExerciseSheets.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace exerciseBox.Rest.Controllers
{
    public class ExerciseSheetController : BaseController
    {
        public ExerciseSheetController(IMediator mediator, ISessionCommunicator sessionCommunicator) : base(mediator, sessionCommunicator) { }

        [HttpGet("GetNewExercise")]
        public async Task<IActionResult> GetNewExerciseSheet()
        {
            var result = await _mediator.Send(new GenerateNewExerciseSheet());
            return File(result, "application/pdf", "example.pdf");
        }
    }
}
