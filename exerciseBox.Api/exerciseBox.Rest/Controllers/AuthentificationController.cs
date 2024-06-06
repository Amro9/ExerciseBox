using exerciseBox.Application.Abtraction.Extensions;
using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Services;
using exerciseBox.Application.Services.Interface;
using exerciseBox.Application.Services.Models;
using exerciseBox.Application.UseCases.Teacher.Queries;
using exerciseBox.Application.UseCases.Teachers.Commands;
using exerciseBox.Rest.Controllers;
using exerciseBox.Rest.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace exercisebox.rest.controllers;

public class AuthentificationController : BaseController
{
    public AuthentificationController(IMediator mediator, ISessionCommunicator sessionCommunicator) : base(mediator, sessionCommunicator)
    {

    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
    {
        try
        {
            var teacher = await _mediator.Send(new GetTeacherWithPasswordValidation { Email = loginRequest.Email, Password = loginRequest.Password });

            if(teacher == null)
            {
                return StatusCode(500, "Während des Logins ist ein Fehler aufgetreten. Bitte versuchen sie es später erneut.");
            }

            var sessionId = _sessionCommunicator.AddNewSessionId(loginRequest.Email);

            return Ok(new { value = sessionId });
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized("Falsches passwort");
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Während des Logins ist ein Fehler aufgetreten. Bitte versuchen sie es später erneut.");
        }
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest RegisterRequest)
    {
        try
        {
            //if(_sessionCommunicator.VerifySessionId(new SessionModel { SessionIdKey = RegisterRequest.SchoolId, SessionId = RegisterRequest.SessionId }))
            //{
            //    return StatusCode(440, "Ihre Sitzung ist abgelaufen. Bitte melden sie sich erneut an.");
            //    //return StatusCode(419, "Ihre Sitzung ist abgelaufen. Bitte melden sie sich erneut an.");
            //}

            ////var pw = $"{RegisterRequest.Surname}.{RegisterRequest.Givenname}";

            var teacher = await _mediator.Send(new CreateTeacher
            {
                Teacher = new TeacherDto
                {
                    ////Email = RegisterRequest.Email,
                    ////Password = pw.HashPassword(),
                    ////Surname = RegisterRequest.Surname,
                    ////Givenname = RegisterRequest.Givenname,
                    ////SchoolId = RegisterRequest.SchoolId
                }
            });

            return Ok(new { value = teacher });
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Während der Registrierung ist ein Fehler aufgetreten. Bitte versuchen sie es später erneut.");
        }
    }
}
