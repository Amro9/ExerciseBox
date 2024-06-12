using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.UseCases.Questions.Commands;
using exerciseBox.Application.UseCases.Questions.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace exerciseBox.Rest.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class QuestionController: Controller
    {
        private readonly IMediator _mediator;
        public QuestionController(IMediator mediator)
        {
            _mediator = mediator;
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

        public void RemoveQuestion() {

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
    }
}
