using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Services.Interface;
using exerciseBox.Application.Services.Models;
using exerciseBox.Application.UseCases.Folder.Queries;
using exerciseBox.Application.UseCases.Subject.Queries;
using exerciseBox.Application.UseCases.Teacher.Queries;
using exerciseBox.Application.UseCases.Teachers.Queries;
using exerciseBox.Rest.Controllers.RequestModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace exerciseBox.Rest.Controllers;

public class TeacherController : BaseController
{
    public TeacherController(IMediator mediator) : base(mediator)
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

            var teachers = await _mediator.Send(new GetTeachersBySchool { SchoolId = school.SchoolId });
            return Ok(new { value = teachers });
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Während des Logins ist ein Fehler aufgetreten. Bitte versuchen sie es später erneut.");
        }
    }

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

}
