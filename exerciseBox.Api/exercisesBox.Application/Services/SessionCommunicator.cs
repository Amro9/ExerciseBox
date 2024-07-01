using exerciseBox.Application.Services.Interface;
using exerciseBox.Application.Services.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Text;
using System.Text.Json;

namespace exerciseBox.Application.Services
{
    /// <summary>
    /// Implementiert Methoden zur Verwaltung von Sitzungsdaten mithilfe von HttpContext.
    /// </summary>
    public class SessionCommunicator : ISessionCommunicator
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="SessionCommunicator"/> Klasse.
        /// </summary>
        /// <param name="httpContextAccessor">Das IHttpContextAccessor-Objekt, das für den Zugriff auf HttpContext benötigt wird.</param>
        public SessionCommunicator(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        /// <summary>
        /// Fügt eine neue Sitzungs-ID hinzu und speichert sie im HttpContext.
        /// </summary>
        /// <returns>Die neu hinzugefügte Sitzungs-ID als Zeichenfolge.</returns>
        public string AddNewSessionId()
        {
            if (_httpContextAccessor.HttpContext == null)
            {
                throw new HttpRequestException("HttpContext ist null");
            }

            var sessionid = Guid.NewGuid().ToString();

            var jsonString = JsonSerializer.Serialize(sessionid);
            var sessionModelBytes = Encoding.UTF8.GetBytes(jsonString);
            _httpContextAccessor.HttpContext.Session.Set($"SessionId", sessionModelBytes);

            return sessionid;
        }

        /// <summary>
        /// Überprüft die Gültigkeit der aktuellen Sitzungs-ID.
        /// </summary>
        /// <returns><c>true</c>, wenn die Sitzungs-ID gültig ist; andernfalls <c>false</c>.</returns>
        public bool VerifySessionId()
        {
            if (_httpContextAccessor.HttpContext == null)
            {
                throw new HttpRequestException("HttpContext ist null");
            }

            byte[] storedSessionModelBytes;
            _httpContextAccessor.HttpContext.Session.TryGetValue($"SessionId", out storedSessionModelBytes);

            return storedSessionModelBytes != null;
        }

        /// <summary>
        /// Ruft die Benutzer-ID aus der aktuellen Sitzung ab.
        /// </summary>
        /// <returns>Die Benutzer-ID als Zeichenfolge oder <c>null</c>, wenn keine Benutzer-ID gespeichert ist.</returns>
        public string GetUserId()
        {
            if (_httpContextAccessor.HttpContext == null)
            {
                throw new HttpRequestException("HttpContext ist null");
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
}
