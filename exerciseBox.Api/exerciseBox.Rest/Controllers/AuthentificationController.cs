using exercisebox.application.usecases.teacher.queries;
using exercisebox.rest.models;
using mediatr;
using microsoft.aspnetcore.mvc;

namespace exercisebox.rest.controllers;

public class authentificationcontroller : basecontroller
{
    public authentificationcontroller(imediator mediator,) : base(mediator)
    {

    }

    [httppost("login")]
    public async task<iactionresult> login([frombody] loginrequest loginrequest)
    {
        try
        {
            var teacher = await _mediator.send(new getteacherwithpasswordvalidation { email = loginrequest.email, password = loginrequest.password });
            return ok(new { value = teacher });
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
