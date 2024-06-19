using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.UseCases.DifficultyLevel.Queries;
using exerciseBox.Application.UseCases.Subject.Queries;
using exerciseBox.Application.UseCases.Topics.Queries;
using exerciseBox.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using exerciseBox.Application.Services.Interface;
using exerciseBox.Application.UseCases.SchoolLevels.Queries;

namespace exerciseBox.Rest.Controllers
{
    public class QuestionParamatersController : BaseController
    {
        public QuestionParamatersController(IMediator mediator, ISessionCommunicator sessionCommunicator) : base(mediator, sessionCommunicator)
        {
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
        [HttpGet("GetSchoolLevelsBySchoolTypeId")]
        public async Task<IEnumerable<int>> GetSchoolLevelsBySchoolTypeId([FromQuery] int schoolTypeId)
        {
            var schoolLevels = await _mediator.Send(new GetSchoolLevelsBySchoolTypeId(schoolTypeId));
            return schoolLevels.OrderBy(level => level);
        }

        [HttpGet("GetSchoolLevelsByTeacherId")]
        public async Task<IEnumerable<int>> GetSchoolLevelsByTeacherId([FromQuery] string teacherId)
        {
            string id = "1@2.com";
            return await _mediator.Send(new GetSchoolLevelsByTeacherId(id));
        }

        [HttpGet("GetDifficultyLevels")]
        public async Task<IEnumerable<DifficultyLevelDto>> GetDifficultyLevels()
        {
            return await _mediator.Send(new GetAllDifficultyLevels());
        }
    }
}
