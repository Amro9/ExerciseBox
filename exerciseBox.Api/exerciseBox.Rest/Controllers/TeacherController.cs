﻿using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.UseCases.Folder.Commands;
using exerciseBox.Application.UseCases.Folder.Queries;
using exerciseBox.Application.UseCases.Subject.Queries;
using exerciseBox.Application.UseCases.Teacher.Commands;
using exerciseBox.Application.UseCases.Teacher.Queries;
using exerciseBox.Application.UseCases.Teachers.Commands;
using exerciseBox.Application.UseCases.Teachers.Queries;
using exerciseBox.Rest.Controllers.RequestModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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

        /// <summary>
        /// Erstellt einen neuen Folder für einen Lehrer
        /// </summary>
        /// <param name="folder">Das <see cref="FolderDto"/>, das erstellt werden soll.</param>
        /// <returns>Ein <see cref="IActionResult"/>.</returns>
        [HttpPost("NewFolder")]
        public async Task<IActionResult> CreateNewFolder([FromBody] NewFolderRequest folder)
        {
            try
            {
                await _mediator.Send(new CreateFolder { Name = folder.FolderName, SubjectId = folder.SubjectId, TeacherId = folder.TeacherId });
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ein Fehler ist aufgetreten. Bitte versuchen Sie es später erneut.");
            }
        }

        /// <summary>
        /// Holt den Ordner, in dem die erstellten Fragen eines Faches gespeichert werden.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Ein <see cref="FolderDto"/> Objekt</returns>
        [HttpPost("CreationFolder")]
        public async Task<IActionResult> GetCreationFolder([FromBody] CreationFolderRequest request)
        {
            try
            {
                var folder = await _mediator.Send(new GetCreationFolder { SubjectId = request.SubjectId, TeacherId = request.UserId });
                return Ok(new { folder });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ein Fehler ist aufgetreten. Bitte versuchen Sie es später erneut.");
            }
        }

        /// <summary>
        /// Deaktiviert einen Lehrer.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Ein <see cref="IActionResult"/></returns>
        [HttpPost("Deactivate/{id}")]
        public async Task<IActionResult> DeactivateTeacher(string id)
        {
            try
            {
                await _mediator.Send(new DeactivateTeacher { TeacherId = id });
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ein Fehler ist aufgetreten. Bitte versuchen Sie es später erneut.");
            }
        }

        /// <summary>
        /// Aktiviert einen Lehrer.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Ein <see cref="IActionResult"/></returns>
        [HttpPost("Activate/{id}")]
        public async Task<IActionResult> ActivateTeacher(string id)
        {
            try
            {
                await _mediator.Send(new ActivateTeacher { TeacherId = id });
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ein Fehler ist aufgetreten. Bitte versuchen Sie es später erneut.");
            }
        }

        /// <summary>
        /// Fügt einem Lehrer Fächer hinzu.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Ein <see cref="IActionResult"/></returns>
        [HttpPost("AddSubject")]
        public async Task<IActionResult> AddSubject([FromBody] SubjectsRequest request)
        {
            try
            {
                await _mediator.Send(new AddSubject { TeacherId = request.TeacherId, SubjectId = request.SubjectId });
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ein Fehler ist aufgetreten. Bitte versuchen Sie es später erneut.");
            }
        }

        /// <summary>
        /// Entfernt einem Lehrer Fächer.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("RemoveSubject")]
        public async Task<IActionResult> RemoveSubject([FromBody] SubjectsRequest request)
        {
            try
            {
                await _mediator.Send(new RemoveSubject { TeacherId = request.TeacherId, SubjectId = request.SubjectId });
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ein Fehler ist aufgetreten. Bitte versuchen Sie es später erneut.");
            }
        }

        /// <summary>
        /// Aktualisiert einen Lehrer.
        /// </summary>
        /// <param name = "request" ></ param >
        /// < returns ></ returns >
        [HttpPost("Update")]
        public async Task<IActionResult> UpdateTeacher([FromBody] TeacherUpdateRequest request)
        {
            try
            {
                await _mediator.Send(new UpdateTeacher { Teacher = request });
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ein Fehler ist aufgetreten. Bitte versuchen Sie es später erneut.");
            }
        }


        /// <summary>
        /// Setzt das Passwort eines Lehrers zurück.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost("ResetPassword/{id}")]
        public async Task<IActionResult> ResetPassword(string id)
        {
            try
            {
                await _mediator.Send(new ResetPassword { Email = id });
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ein Fehler ist aufgetreten. Bitte versuchen Sie es später erneut.");
            }
        }

        /// <summary>
        /// Fügt einen neuen Lehrer hinzu.
        /// </summary>
        /// <param name="teacher"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        public async Task<IActionResult> AddTeacher([FromBody] TeacherUpdateRequest teacher)
        {
            try
            {
                teacher.Password = teacher.Surname + "." + teacher.Givenname;

                await _mediator.Send(new CreateTeacher { Teacher = teacher });
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ein Fehler ist aufgetreten. Bitte versuchen Sie es später erneut.");
            }
        }

        /// <summary>
        /// Holt alle Schulzweige eines Lehrers.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Branche/{id}")]
        public async Task<IActionResult> GetBrancheOfTeacher(string id)
        {
            try
            {
                var branche = await _mediator.Send(new GetBrancheOfTeacher { TeacherId = id });
                return Ok(new { value = branche });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ein Fehler ist aufgetreten. Bitte versuchen Sie es später erneut.");
            }
        }
    }
}
