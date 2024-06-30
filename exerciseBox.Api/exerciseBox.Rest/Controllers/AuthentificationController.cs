using exerciseBox.Application.Abtraction.Extensions;
using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.UseCases.Schools.Queries;
using exerciseBox.Application.UseCases.Teacher.Commands;
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

namespace exercisebox.rest.controllers
{
    /// <summary>
    /// Controller für Authentifizierungs- und Autorisierungsoperationen.
    /// </summary>
    public class AuthentificationController : BaseController
    {
        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="AuthentificationController"/> Klasse.
        /// </summary>
        /// <param name="mediator">Der MediatR-Mediator.</param>
        public AuthentificationController(IMediator mediator) : base(mediator)
        {

        }

        /// <summary>
        /// Versucht, einen Benutzer anzumelden.
        /// </summary>
        /// <param name="loginRequest">Die Anmeldeanforderung mit E-Mail und Passwort.</param>
        /// <returns>Eine <see cref="IActionResult"/> Rückgabe mit der Benutzer-ID und Rolle.</returns>
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            try
            {
                User user = await _mediator.Send(new GetTeacherWithPasswordValidation { Email = loginRequest.Email, Password = loginRequest.Password });

                if (user == null)
                {
                    user = await _mediator.Send(new GetSchoolWithPasswordValidation { Email = loginRequest.Email, Password = loginRequest.Password });

                    if (user == null)
                        return StatusCode(500, "Mit dieser Email wurde kein Account gefunden.");

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
                return Unauthorized("Falsches Passwort");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Während des Logins ist ein Fehler aufgetreten. Bitte versuchen Sie es später erneut.");
            }
        }

        /// <summary>
        /// Registriert einen neuen Lehrer.
        /// </summary>
        /// <param name="RegisterRequest">Die Anfrage zum Registrieren eines Lehrers.</param>
        /// <returns>Eine <see cref="IActionResult"/> Rückgabe mit dem registrierten Lehrer.</returns>
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
                return StatusCode(500, "Während der Registrierung ist ein Fehler aufgetreten. Bitte versuchen Sie es später erneut.");
            }
        }

        /// <summary>
        /// Aktualisiert das Token des Benutzers.
        /// </summary>
        /// <returns>Eine <see cref="IActionResult"/> Rückgabe.</returns>
        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken()
        {
            try
            {
                var role = User.FindFirstValue(ClaimTypes.Role); // Rolle aus den Benutzerclaims abrufen

                await CreateCookiesAsync(role, User.Identity.Name);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Während der Aktualisierung des Tokens ist ein Fehler aufgetreten. Bitte versuchen Sie es später erneut.");
            }
        }

        /// <summary>
        /// Meldet den Benutzer ab.
        /// </summary>
        /// <returns>Eine <see cref="IActionResult"/> Rückgabe.</returns>
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
                return StatusCode(500, "Während des Logouts ist ein Fehler aufgetreten. Bitte versuchen Sie es später erneut.");
            }
        }

        /// <summary>
        /// Holt die Rolle des angemeldeten Benutzers.
        /// </summary>
        /// <returns>Eine <see cref="IActionResult"/> Rückgabe mit der Rolle des Benutzers.</returns>
        [HttpGet("Role")]
        public async Task<IActionResult> GetRole()
        {
            try
            {
                var role = User.FindFirstValue(ClaimTypes.Role); // Rolle aus den Benutzerclaims abrufen

                return Ok(new { Role = role });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Während des Abrufs der Benutzerrolle ist ein Fehler aufgetreten. Bitte versuchen Sie es später erneut.");
            }
        }

        [HttpGet("IsPasswordDefault/{id}")]
        public async Task<IActionResult> IsPasswordDefault(string id)
        {
            try
            {
                var teacher = await _mediator.Send(new GetTeacherByEmail { Email = id });

                if (teacher == null)
                    return StatusCode(500, "Der Lehrer wurde nicht gefunden.");

                if (teacher.Password == $"{teacher.Surname}.{teacher.Givenname}".HashPassword())
                    return Ok(new { IsDefault = true });

                return Ok(new { IsDefault = false });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Während der Überprüfung des Passworts ist ein Fehler aufgetreten. Bitte versuchen Sie es später erneut.");
            }
        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest changePasswordRequest)
        {
            try
            {
                var teacher = await _mediator.Send(new GetTeacherByEmail { Email = changePasswordRequest.Email });

                if (teacher == null)
                    return StatusCode(500, "Der Lehrer wurde nicht gefunden.");

                if (teacher.Password != changePasswordRequest.OldPassword.HashPassword())
                    return StatusCode(500, "Das alte Passwort ist falsch.");

                teacher.Password = changePasswordRequest.NewPassword.HashPassword();

                await _mediator.Send(new UpdatePassword { Email = teacher.Email, Password = changePasswordRequest.NewPassword });

                return Ok(new { value = true });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Während der Passwortänderung ist ein Fehler aufgetreten. Bitte versuchen Sie es später erneut.");
            }
        }

        /// <summary>
        /// Erstellt die Cookies für den angemeldeten Benutzer.
        /// </summary>
        /// <param name="Role"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
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
}
