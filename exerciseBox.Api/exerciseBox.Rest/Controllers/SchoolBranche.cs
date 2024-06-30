using exerciseBox.Application.UseCases.Subject.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace exerciseBox.Rest.Controllers
{
    /// <summary>
    /// Controller für Schulzweige.
    /// </summary>
    public class SchoolBranch : BaseController
    {
        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="SchoolBranch"/> Klasse.
        /// </summary>
        /// <param name="mediator"></param>
        public SchoolBranch(IMediator mediator) : base(mediator)
        {

        }

        /// <summary>
        /// Holt alle Fächer eines Schulzweigs. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Subjects/{id}")]
        public async Task<IActionResult> GetSubjectOfBranch(string id)
        {
            try
            {
                var subject = await _mediator.Send(new GetBranchSubjects { BranchId = id});

                return Ok(new { value = subject });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ein Fehler ist aufgetreten. Bitte versuchen Sie es später erneut.");
            }
        }
    }
}
