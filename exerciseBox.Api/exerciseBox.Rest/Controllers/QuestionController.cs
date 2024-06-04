using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.UseCases.Questions.Queries;
using exerciseBox.Rest.Models;
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
        public async void AddQuestion([FromBody] QuestionModel question)
        {
           //await _mediator.Send(new )
        }

        public void RemoveQuestion() {

        }


        [HttpGet("Questions")]
        public async Task<IEnumerable<QuestionDto>> GetAllQuestions()
        {
            try
            {
                    await _mediator.Send(new GetAllQuestions());
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
                return null;
        }
    }
}
