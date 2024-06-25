using exerciseBox.Application.Services.Interface;
using exerciseBox.Application.Services.Models;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.Text.Json;

namespace exerciseBox.Application.Services;

public class SessionCommunicator : ISessionCommunicator
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public SessionCommunicator(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string AddNewSessionId()
    {
        if (_httpContextAccessor.HttpContext == null)
        {
            throw new HttpRequestException("HttpContext is null");
        }

        var sessionid = Guid.NewGuid().ToString();

        var jsonString = JsonSerializer.Serialize(sessionid);
        var sessionModelBytes = Encoding.UTF8.GetBytes(jsonString);
        _httpContextAccessor.HttpContext.Session.Set($"SessionId", sessionModelBytes);

        return sessionid;
    }

    public bool VerifySessionId()
    {
        if (_httpContextAccessor.HttpContext == null)
        {
            throw new HttpRequestException("HttpContext is null");
        }

        byte[] storedSessionModelBytes;
        _httpContextAccessor.HttpContext.Session.TryGetValue($"SessionId", out storedSessionModelBytes);

        if (storedSessionModelBytes == null)
        {
            return false;
        }
        return true;
    }

    public string GetUserId()
    {
        if (_httpContextAccessor.HttpContext == null)
        {
            throw new HttpRequestException("HttpContext is null");
        }

        byte[] storedSessionModelBytes;
        _httpContextAccessor.HttpContext.Session.TryGetValue($"UserId", out storedSessionModelBytes);

        if (storedSessionModelBytes == null)
        {
            return null;
        }

        var storedSessionModelJson = Encoding.UTF8.GetString(storedSessionModelBytes);
        return JsonSerializer.Deserialize<string>(storedSessionModelJson);
    }
}
