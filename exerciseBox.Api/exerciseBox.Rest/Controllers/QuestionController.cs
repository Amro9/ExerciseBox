using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.UseCases.Questions.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace exerciseBox.Rest.Controllers
{
    public class QuestionController: Controller
    {
        private readonly IMediator _mediator;
        public QuestionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public void AddQuestion()
        {

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
