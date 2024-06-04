using exerciseBox.Application.Services.Interface;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace exerciseBox.Application.Services;

public class SessionCommunicator : ISessionCommunicator
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public SessionCommunicator(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string AddNewSessionId(string email)
    {
        if (_httpContextAccessor.HttpContext == null)
        {
            throw new HttpRequestException("HttpContext is null");
        }

        var sessionid = Guid.NewGuid().ToString();

        var sessionModel = new SessionModel
        {
            SessionIdKey = email,
            SessionId = sessionid
        };  

        _httpContextAccessor.HttpContext.Session.Set("sessionid", Encoding.UTF8.GetBytes(sessionid));
        return sessionid;
    }

    public bool VerifySessionId(string sessionId)
    {
        if (_httpContextAccessor.HttpContext == null)
        {
            throw new HttpRequestException("HttpContext is null");
        }

        byte[] storedSessionId;
        _httpContextAccessor.HttpContext.Session.TryGetValue("sessionid", out storedSessionId);

        if (storedSessionId == null)
        {
            return false; // Keine Session-ID gefunden
        }

        var storedSessionIdString = Encoding.UTF8.GetString(storedSessionId);
        return storedSessionIdString == sessionId;
    }
}
