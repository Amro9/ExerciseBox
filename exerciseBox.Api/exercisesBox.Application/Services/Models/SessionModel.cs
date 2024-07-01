using System.Text;
using System.Text.Json;

namespace exerciseBox.Application.Services.Models
{
    /// <summary>
    /// Stellt eine Modellklasse für eine Sitzung dar.
    /// </summary>
    public class SessionModel
    {
        /// <summary>
        /// Der Schlüssel für die Sitzungs-ID.
        /// </summary>
        public string SessionIdKey { get; set; }

        /// <summary>
        /// Die Sitzungs-ID.
        /// </summary>
        public string SessionId { get; set; }

        /// <summary>
        /// Deserialisiert ein Byte-Array in ein <see cref="SessionModel"/>-Objekt.
        /// </summary>
        /// <param name="byteArray">Das Byte-Array, das deserialisiert werden soll.</param>
        /// <returns>Das deserialisierte <see cref="SessionModel"/>-Objekt oder <c>null</c>, wenn das Eingabe-Byte-Array <c>null</c> ist.</returns>
        public static SessionModel DeserializeSessionModel(byte[] byteArray)
        {
            if (byteArray == null)
                return null;

            string jsonString = Encoding.UTF8.GetString(byteArray);
            SessionModel sessionModel = JsonSerializer.Deserialize<SessionModel>(jsonString);
            return sessionModel;
        }

        /// <summary>
        /// Serialisiert ein <see cref="SessionModel"/>-Objekt in ein Byte-Array.
        /// </summary>
        /// <param name="sessionModel">Das <see cref="SessionModel"/>-Objekt, das serialisiert werden soll.</param>
        /// <returns>Das serialisierte Byte-Array.</returns>
        public static byte[] SerializeSessionModel(SessionModel sessionModel)
        {
            var jsonString = JsonSerializer.Serialize(sessionModel);
            return Encoding.UTF8.GetBytes(jsonString);
        }
    }
}
