using exerciseBox.Application.Abtraction.Extensions;
using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Services;
using exerciseBox.Application.Services.Interface;
using exerciseBox.Application.Services.Models;
using exerciseBox.Application.UseCases.Teacher.Queries;
using exerciseBox.Application.UseCases.Teachers.Commands;
using exerciseBox.Rest.Controllers;
using exerciseBox.Rest.Controllers.RequestModels;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace exercisebox.rest.controllers;

public class AuthentificationController : BaseController
{
    public AuthentificationController(IMediator mediator) : base(mediator)
    {

    }

    [HttpPost("Login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginRequest loginRequest)
    {
        try
        {
            var teacher = await _mediator.Send(new GetTeacherWithPasswordValidation { Email = loginRequest.Email, Password = loginRequest.Password });

            if (teacher == null)
            {
                return StatusCode(500, "Während des Logins ist ein Fehler aufgetreten. Bitte versuchen sie es später erneut.");
            }

            //var sessionId = _sessionCommunicator.AddNewSessionId();


            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, teacher.Email),
                new Claim(ClaimTypes.Role, "Teacher")
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60)
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);


            return Ok(new { Id = teacher.Email });
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
    public async Task<IActionResult> Register([FromBody] TeacherDto RegisterRequest)
    {
        try
        {
            var pw = $"{RegisterRequest.Surname}.{RegisterRequest.Givenname}";

            var teacher = await _mediator.Send(new CreateTeacher
            {
                Teacher = RegisterRequest
            });

            return Ok(new { value = teacher });
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Während der Registrierung ist ein Fehler aufgetreten. Bitte versuchen sie es später erneut.");
        }
    }

    [HttpPost("RefreshToken")]
    public async Task<IActionResult> RefreshToken()
    {
        try
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, User.Identity.Name),
                new Claim(ClaimTypes.Role, "Teacher")
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60)
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Während der Registrierung ist ein Fehler aufgetreten. Bitte versuchen sie es später erneut.");
        }
    }
}
