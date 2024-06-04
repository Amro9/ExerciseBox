using exerciseBox.Application.UseCases.Teacher.Queries;
using exerciseBox.Rest.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace exerciseBox.Rest.Controllers;

public class AuthentificationController : BaseController
{
    public AuthentificationController(IMediator mediator,) : base(mediator)
    {

    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
    {
        try
        {
            var teacher = await _mediator.Send(new GetTeacherWithPasswordValidation { Email = loginRequest.Email, Password = loginRequest.Password });
            return Ok(new { value = teacher });
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized("Falsches Passwort");
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Während des Logins ist ein Fehler aufgetreten. Bitte versuchen sie es später erneut.");
        }
    }

    //[HttpPost("Register")]
    //public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
    //{
    //    try
    //    {
    //        var teacher = await _mediator.Send(new RegisterTeacher { Email = registerRequest.Email, Password = registerRequest.Password });
    //        return Ok(new { value = teacher });
    //    }
    //    catch (Exception ex)
    //    {
    //        return StatusCode(500, "Während der Registrierung ist ein Fehler aufgetreten. Bitte versuchen sie es später erneut.");
    //    }
    //}
}
