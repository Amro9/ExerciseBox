using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Services.Interface;
using exerciseBox.Application.UseCases.Questions.Commands;
using exerciseBox.Application.UseCases.Questions.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace exerciseBox.Rest.Controllers
{
   
    public class QuestionController: BaseController
    {
        public QuestionController(IMediator mediator, ISessionCommunicator sessionCommunicator) : base(mediator, sessionCommunicator)
        {
            
        }

        [HttpPost("addQuestion")]
        public async Task<IActionResult> AddQuestion([FromBody] QuestionDto question)
        {
            try
            {
                await _mediator.Send(new CreateQuestion { Question = question });
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ein Problem ist aufgetreten. Hier müssen wir uns auf Messages einigen");
            }
        }

        [HttpGet("publicQuestions")]
        public async Task<IEnumerable<QuestionDto>> GetPublicQuestions()
        {
            try
            {
                   return await _mediator.Send(new GetPublicQuestions());
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
                return null;
        }

        [HttpGet("folderQuestions/{folderId}")]
        public async Task<IActionResult> GetFolderQuestions(string folderId)
        {
            try
            {
                var questions = await _mediator.Send(new GetFolderQuestions { FolderId = folderId });
                return Ok(new {value = questions});
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ein Problem ist aufgetreten. Hier müssen wir uns auf Messages einigen");
            }
        }
    }
}
