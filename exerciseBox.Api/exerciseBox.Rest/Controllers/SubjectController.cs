using exerciseBox.Application.UseCases.Folder.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace exerciseBox.Rest.Controllers
{
    public class SubjectController : BaseController
    {
        public IMediator Mediator { get; }
        public SubjectController(IMediator mediator) : base(mediator)
        {
            Mediator = mediator;
        }


        /// <summary>
        /// Hollt alle Fächer eines Lehrers anhand der SubjectId
        /// </summary>
        /// <param name="subjectId"></param>
        /// <param name="teacherId"></param>
        /// <returns></returns>
        [HttpGet("Folders/{subjectId}/{teacherId}")]
        public async Task<IActionResult> GetFoldersOfSubject(string subjectId, string teacherId)
        {
            try
            {
                var folders = await Mediator.Send(new GetSubjectFolders (  subjectId,teacherId ));
                return Ok(new { value = folders });
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, "Ein Fehler ist aufgetreten. Bitte versuchen Sie es später erneut.");
            }
        }
    }
}
