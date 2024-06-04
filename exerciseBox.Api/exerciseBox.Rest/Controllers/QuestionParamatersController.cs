using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.UseCases.DifficultyLevel.Queries;
using exerciseBox.Application.UseCases.Subject.Queries;
using exerciseBox.Application.UseCases.Topics.Queries;
using exerciseBox.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace exerciseBox.Rest.Controllers
{
    public class QuestionParamatersController : Controller
    {
        private readonly IMediator _mediator;
        public QuestionParamatersController(IMediator mediator)
        {
               _mediator = mediator;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("Subjects")]
        public async Task<IEnumerable<SubjectDto>> GetAllSubjects()
        {
            return await _mediator.Send(new GetAllSubjects());
        }

        [HttpGet("Topics")]
        public async Task<IEnumerable<TopicDto>> GetAllTopics()
        {
            return await _mediator.Send(new GetAllTopics());
        }

        [HttpGet("GetTopicBySubject/{subject}")]
        public async Task<IEnumerable<TopicDto>> GetTopicBySubject(string subject)
        {
            return await _mediator.Send(new GetTopicsBySubject(subject));
        }
        public async void GetAllClasses()
        {
            // hier werden die schulstufen geholt und in klassen umgewandelt .. nur ein vorschlag
        }

        [HttpGet("GetAllDifficultyLevel")]
        public async Task<IEnumerable<DifficultyLevelDto>> GettAllDifficultyLevel()
        {
            return await _mediator.Send(new GetAllDifficultyLevels());
        }
    }
}
