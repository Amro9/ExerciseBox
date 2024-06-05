using exerciseBox.Application.Services.Interface;
using exerciseBox.Application.UseCases.Teacher.Queries;
using exerciseBox.Rest.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace exercisebox.rest.controllers;

public class authentificationcontroller : basecontroller
{
    private readonly ISessionCommunicator _sessionCommunicator;

    public AuthentificationController(IMediator mediator, ISessionCommunicator sessionCommunicator) : base(mediator)
    {
        _sessionCommunicator = sessionCommunicator;
    }

    [httppost("login")]
    public async task<iactionresult> login([frombody] loginrequest loginrequest)
    {
        try
        {
            var teacher = await _mediator.Send(new GetTeacherWithPasswordValidation { Email = loginRequest.Email, Password = loginRequest.Password });

            if(teacher == null)
            {
                return StatusCode(500, "Während des Logins ist ein Fehler aufgetreten. Bitte versuchen sie es später erneut.");
            }

            var sessionId = _sessionCommunicator.AddNewSessionId(string email);

            return Ok(new { value = sessionId });
        }
        catch (unauthorizedaccessexception ex)
        {
            return unauthorized("falsches passwort");
        }
        catch (exception ex)
        {
            return statuscode(500, "während des logins ist ein fehler aufgetreten. bitte versuchen sie es später erneut.");
        }
    }

    //[httppost("register")]
    //public async task<iactionresult> register([frombody] registerrequest registerrequest)
    //{
    //    try
    //    {
    //        var teacher = await _mediator.send(new registerteacher { email = registerrequest.email, password = registerrequest.password });
    //        return ok(new { value = teacher });
    //    }
    //    catch (exception ex)
    //    {
    //        return statuscode(500, "während der registrierung ist ein fehler aufgetreten. bitte versuchen sie es später erneut.");
    //    }
    //}
}
