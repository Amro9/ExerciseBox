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
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exerciseBox.Rest.Controllers
{
    /// <summary>
    /// Controller für Abfragen von Frageparametern.
    /// </summary>
    public class QuestionParametersController : BaseController
    {
        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="QuestionParametersController"/> Klasse.
        /// </summary>
        /// <param name="mediator">Der MediatR-Mediator.</param>
        public QuestionParametersController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Holt alle Fächer.
        /// </summary>
        /// <returns>Eine Liste von <see cref="SubjectDto"/> Objekten.</returns>
        [HttpGet("Subjects")]
        public async Task<IEnumerable<SubjectDto>> GetAllSubjects()
        {
            return await _mediator.Send(new GetAllSubjects());
        }

        /// <summary>
        /// Holt alle Themen.
        /// </summary>
        /// <returns>Eine Liste von <see cref="TopicDto"/> Objekten.</returns>
        [HttpGet("Topics")]
        public async Task<IEnumerable<TopicDto>> GetAllTopics()
        {
            return await _mediator.Send(new GetAllTopics());
        }

        /// <summary>
        /// Holt Themen anhand des Fachs.
        /// </summary>
        /// <param name="subject">Das Fach.</param>
        /// <returns>Eine Liste von <see cref="TopicDto"/> Objekten.</returns>
        [HttpGet("GetTopicBySubject/{subject}")]
        public async Task<IEnumerable<TopicDto>> GetTopicBySubject(string subject)
        {
            return await _mediator.Send(new GetTopicsBySubject(subject));
        }

        /// <summary>
        /// Holt Schulstufen anhand der Schulart-ID.
        /// </summary>
        /// <param name="schoolTypeId">Die ID der Schulart.</param>
        /// <returns>Eine sortierte Liste von Schulstufen als <see cref="IEnumerable{int}"/>.</returns>
        [HttpGet("GetSchoolLevelsBySchoolTypeId")]
        public async Task<IEnumerable<int>> GetSchoolLevelsBySchoolTypeId([FromQuery] int schoolTypeId)
        {
            var schoolLevels = await _mediator.Send(new GetSchoolLevelsBySchoolTypeId(schoolTypeId));
            return schoolLevels.OrderBy(level => level);
        }

        /// <summary>
        /// Holt Schulstufen anhand der Lehrer-ID.
        /// </summary>
        /// <param name="teacherId">Die ID des Lehrers.</param>
        /// <returns>Eine Liste von Schulstufen als <see cref="IEnumerable{int}"/>.</returns>
        [HttpGet("GetSchoolLevelsByTeacherId")]
        public async Task<IEnumerable<int>> GetSchoolLevelsByTeacherId([FromQuery] string teacherId)
        {
            return await _mediator.Send(new GetSchoolLevelsByTeacherId(teacherId));
        }

        /// <summary>
        /// Holt alle Schwierigkeitsstufen.
        /// </summary>
        /// <returns>Eine Liste von <see cref="DifficultyLevelDto"/> Objekten.</returns>
        [HttpGet("GetDifficultyLevels")]
        public async Task<IEnumerable<DifficultyLevelDto>> GetDifficultyLevels()
        {
            return await _mediator.Send(new GetAllDifficultyLevels());
        }
    }
}
