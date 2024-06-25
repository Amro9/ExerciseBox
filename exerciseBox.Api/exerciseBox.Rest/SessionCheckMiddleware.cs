public class SessionCheckMiddleware
{
    private readonly RequestDelegate _next;

    public SessionCheckMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var session = context.Session;
        var lastAccessTime = session.GetString("LastAccessTime");
        var sessionExpiryTime = session.GetString("SessionExpiryTime");

        if (!string.IsNullOrEmpty(lastAccessTime) && !string.IsNullOrEmpty(sessionExpiryTime))
        {
            DateTime lastAccess;
            DateTime expiryTime;
            if (DateTime.TryParse(lastAccessTime, out lastAccess) && DateTime.TryParse(sessionExpiryTime, out expiryTime))
            {
                if (DateTime.UtcNow > expiryTime)
                {
                    var timeSinceExpiry = DateTime.UtcNow - expiryTime;
                    if (timeSinceExpiry <= TimeSpan.FromMinutes(5))
                    {
                        context.Response.StatusCode = StatusCodes.Status419AuthenticationTimeout;
                        await context.Response.WriteAsync("Session recently expired.");
                        return;
                    }
                }
            }
        }

        session.SetString("LastAccessTime", DateTime.UtcNow.ToString("o"));

        session.SetString("SessionExpiryTime", (DateTime.UtcNow.AddMinutes(15)).ToString("o"));

        await _next(context);
    }
}
