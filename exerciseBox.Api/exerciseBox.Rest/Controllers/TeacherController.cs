using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Services.Interface;
using exerciseBox.Application.Services.Models;
using exerciseBox.Application.UseCases.Folder.Queries;
using exerciseBox.Application.UseCases.Teacher.Queries;
using exerciseBox.Application.UseCases.Teachers.Queries;
using exerciseBox.Rest.Controllers.RequestModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace exerciseBox.Rest.Controllers;

public class TeacherController : BaseController
{
    public TeacherController(IMediator mediator, ISessionCommunicator sessionCommunicator) : base(mediator, sessionCommunicator)
    {
    }

    [HttpGet("All")]
    public async Task<IEnumerable<TeacherDto>> GetAllTeachers()
    {
        return await _mediator.Send(new GetAllTeachers());
    }

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

    [HttpPost("BySchool")]
    public async Task<IActionResult> GetTeacherBySchool([FromBody] SchoolRequest school)
    {
        try
        {
            if(!_sessionCommunicator.VerifySessionId(new SessionModel { SessionId = school.Seesionid, SessionIdKey = school.SchoolId}))
                return StatusCode(440, "Ihre Sitzung ist abgelaufen. Bitte melden sie sich erneut an.");

            var teachers = await _mediator.Send(new GetTeachersBySchool { SchoolId = school.SchoolId });
            return Ok(new { value = teachers });
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Während des Logins ist ein Fehler aufgetreten. Bitte versuchen sie es später erneut.");
        }
    }

    [HttpGet("Folders")]
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

}
