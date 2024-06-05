﻿using exerciseBox.Application.Services.Interface;
using exerciseBox.Application.Services.Models;
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

    public string AddNewSessionId(string Id)
    {
        if (_httpContextAccessor.HttpContext == null)
        {
            throw new HttpRequestException("HttpContext is null");
        }

        var sessionid = Guid.NewGuid().ToString();

        var sessionModel = new SessionModel
        {
            SessionIdKey = Id,
            SessionId = sessionid
        };

        var sessionModelBytes = Encoding.UTF8.GetBytes(sessionModel.ToString());
        _httpContextAccessor.HttpContext.Session.Set($"session{sessionModel.SessionIdKey}", sessionModelBytes);

        return sessionid;
    }

    public bool VerifySessionId(SessionModel session)
    {
        if (_httpContextAccessor.HttpContext == null)
        {
            throw new HttpRequestException("HttpContext is null");
        }

        byte[] storedSessionModelBytes;
        _httpContextAccessor.HttpContext.Session.TryGetValue($"session{session.SessionIdKey}", out storedSessionModelBytes);

        if (storedSessionModelBytes == null)
        {
            return false;
        }

        var storedSessionModelString = Encoding.UTF8.GetString(storedSessionModelBytes);
        //var storedSessionModel = SessionModel.Parse(storedSessionModelString);

        //return storedSessionModel.SessionId == session.SessionId;
        return true;
    }
}
