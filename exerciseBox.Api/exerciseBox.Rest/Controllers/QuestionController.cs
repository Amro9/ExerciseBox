using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Services;
using exerciseBox.Application.Services.Interface;
using exerciseBox.Application.UseCases.Questions.Commands;
using exerciseBox.Application.UseCases.Questions.Queries;
using exerciseBox.Rest.Controllers.RequestModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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
                //schulfach müssen noch vom lehrer profil kommen
                var validationContext = new ValidationContext(question);
                Validator.ValidateObject(question, validationContext);

                await _mediator.Send(new CreateQuestion { Question = question });
                return Ok();
            }
            catch (ValidationException ex)
            {
                return BadRequest($"Validierungsfehler: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ein Problem ist aufgetreten: {ex.Message}");

            }
        }
        [HttpGet("SearchQuestions")]
        public async Task<IActionResult> SearchQuestions([FromQuery] QuestionSearchParamsRequest parameters)
        {
            try
            {
               IEnumerable<QuestionDto> questions;
                //var questions = new Enumerable<QuestionDto>();
                //var questions = new List<QuestionDto>();
                if (!string.IsNullOrEmpty(parameters.Subject))
                {
                     questions = await _mediator.Send(new GetPublicQuestionsBySubject(parameters.Subject));
                }else
                {

                 questions = await _mediator.Send(new GetAllPublicQuestions());
                }
                var filteredQuestions = QuestionsFilter.Filter(questions, parameters);
                return Ok(filteredQuestions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ein Problem ist aufgetreten. Hier müssen wir uns auf Messages einigen");
            }
        }

        //[HttpGet("publicQuestions")]
        //public async Task<IEnumerable<QuestionDto>> GetPublicQuestions()
        //{
        //    try
        //    {
        //           return await _mediator.Send(new GetAllPublicQuestions());
        //    }catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //        return null;
        //}

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
