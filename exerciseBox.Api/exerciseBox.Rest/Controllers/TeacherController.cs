using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Services.Interface;
using exerciseBox.Application.Services.Models;
using exerciseBox.Application.UseCases.Folder.Commands;
using exerciseBox.Application.UseCases.Folder.Queries;
using exerciseBox.Application.UseCases.Subject.Queries;
using exerciseBox.Application.UseCases.Teacher.Queries;
using exerciseBox.Application.UseCases.Teachers.Queries;
using exerciseBox.Rest.Controllers.RequestModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace exerciseBox.Rest.Controllers
{
    /// <summary>
    /// Controller für Lehreroperationen.
    /// </summary>
    public class TeacherController : BaseController
    {
        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="TeacherController"/> Klasse.
        /// </summary>
        /// <param name="mediator">Der MediatR-Mediator.</param>
        public TeacherController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Holt alle Lehrer.
        /// </summary>
        /// <returns>Eine Liste von <see cref="TeacherDto"/> Objekten.</returns>
        [HttpGet("All")]
        public async Task<IEnumerable<TeacherDto>> GetAllTeachers()
        {
            return await _mediator.Send(new GetAllTeachers());
        }

        /// <summary>
        /// Holt einen Lehrer anhand der E-Mail.
        /// </summary>
        /// <param name="email">Die E-Mail-Adresse des Lehrers.</param>
        /// <returns>Ein <see cref="TeacherDto"/> Objekt.</returns>
        [HttpPost("ByEmail")]
        public async Task<IActionResult> GetTeacherByEmail([FromBody] EmailRequest email)
        {
            try
            {
                var teacher = await _mediator.Send(new GetTeacherByEmail { Email = email.Email });
                return Ok(new { value = teacher });
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Holt Lehrer anhand der Schule.
        /// </summary>
        /// <param name="school">Das Objekt, das die Schulkennung enthält.</param>
        /// <returns>Ein <see cref="IActionResult"/> mit der Liste von Lehrern.</returns>
        [HttpPost("BySchool")]
        public async Task<IActionResult> GetTeacherBySchool([FromBody] SchoolRequest school)
        {
            try
            {
                var teachers = await _mediator.Send(new GetTeachersBySchool { SchoolId = school.SchoolId });
                return Ok(new { value = teachers });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Während des Logins ist ein Fehler aufgetreten. Bitte versuchen sie es später erneut.");
            }
        }

        /// <summary>
        /// Holt die Ordner eines Lehrers anhand der ID.
        /// </summary>
        /// <param name="id">Die ID des Lehrers.</param>
        /// <returns>Ein <see cref="IActionResult"/> mit der Liste von Ordnern.</returns>
        [HttpGet("Folders/{id}")]
        public async Task<IActionResult> GetFoldersOfTeacher(string id)
        {
            try
            {
                var folders = await _mediator.Send(new GetFoldersOfTeacher { TeacherId = id });
                return Ok(new { value = folders });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ein Fehler ist aufgetreten. Bitte versuchen Sie es später erneut.");
            }
        }

        /// <summary>
        /// Holt die Fächer eines Lehrers anhand der ID.
        /// </summary>
        /// <param name="id">Die ID des Lehrers.</param>
        /// <returns>Ein <see cref="IActionResult"/> mit der Liste von Fächern.</returns>
        [HttpGet("Subjects/{id}")]
        public async Task<IActionResult> GetTeachersSubjects(string id)
        {
            try
            {
                var subjects = await _mediator.Send(new GetTeachersSubjects { TeacherId = id });
                return Ok(new { value = subjects });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ein Fehler ist aufgetreten. Bitte versuchen Sie es später erneut.");
            }
        }

        [HttpPost("NewFolder")]
        public async Task<IActionResult> CreateNewFolder([FromBody] FolderDto folder)
        {
            try
            {
                await _mediator.Send(new CreateFolder { Folder = folder });
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ein Fehler ist aufgetreten. Bitte versuchen Sie es später erneut.");
            }
        }

    }
}
