using exerciseBox.Application.Services.Interface;

namespace exerciseBox.Rest;

public class CustomMiddleWare
{
    private readonly RequestDelegate _next;
    private readonly ISessionCommunicator _sessionCommunicator;
    public CustomMiddleWare(RequestDelegate next, ISessionCommunicator sessionCommunicator)
    {
        _next = next;
        _sessionCommunicator = sessionCommunicator;
    }

    public async Task Invoke(HttpContext context)
    {
        var request = context.Request;
        var response = context.Response;

        if (request.Path.StartsWithSegments("/api"))
        {
            if(request.Path.StartsWithSegments("/api/Authentification/Login"))
            {
                await _next(context);
                return;
            }
            if (!_sessionCommunicator.VerifySessionId())
            {
                response.StatusCode = 440;
                await response.WriteAsync("Ihre Sitzung ist abgelaufen. Bitte melden sie sich erneut an.");
                return;
            }
        }

        await _next(context);
    }
}
