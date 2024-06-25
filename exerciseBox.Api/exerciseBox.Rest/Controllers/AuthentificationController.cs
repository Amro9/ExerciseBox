using exerciseBox.Application.Abtraction.Extensions;
using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Services;
using exerciseBox.Application.Services.Interface;
using exerciseBox.Application.Services.Models;
using exerciseBox.Application.UseCases.Schools.Queries;
using exerciseBox.Application.UseCases.Teacher.Queries;
using exerciseBox.Application.UseCases.Teachers.Commands;
using exerciseBox.Rest.Controllers;
using exerciseBox.Rest.Controllers.RequestModels;
using exerciseBox.Rest.Controllers.ResponseModels;
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
            User user = await _mediator.Send(new GetTeacherWithPasswordValidation { Email = loginRequest.Email, Password = loginRequest.Password });

            if (user == null)
            {
                user = await _mediator.Send(new GetSchoolWithPasswordValidation { SchoolId = loginRequest.Email, Password = loginRequest.Password });
              

                if (user == null)
                    return StatusCode(500, "Während des Logins ist ein Fehler aufgetreten. Bitte versuchen sie es später erneut.");
                
                user.Role = "School";
            }
            else
            {
                user.Role = "Teacher";
            }

            await CreateCookiesAsync(user.Role, user.Email);

            return Ok(new { Id = user.Email, Role = user.Role });
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
            var role = User.FindFirstValue(ClaimTypes.Role); 

            await CreateCookiesAsync(role, User.Identity.Name);

            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Während der Registrierung ist ein Fehler aufgetreten. Bitte versuchen sie es später erneut.");
        }
    }

    [HttpPost("Logout")]
    public async Task<IActionResult> Logout()
    {
        try
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Während des Logouts ist ein Fehler aufgetreten. Bitte versuchen sie es später erneut.");
        }
    }

    [HttpGet("Role")]
    public async Task<IActionResult> GetRole()
    {
        try
        {
            var role = User.FindFirstValue(ClaimTypes.Role); // Retrieve the role from the user claims

            return Ok(new { Role = role });
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Während des Logouts ist ein Fehler aufgetreten. Bitte versuchen sie es später erneut.");
        }
    }

    private async Task CreateCookiesAsync(string Role, string Name)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, Name),
            new Claim(ClaimTypes.Role, Role)
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
    }
}
