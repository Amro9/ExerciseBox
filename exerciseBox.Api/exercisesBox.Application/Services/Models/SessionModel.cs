using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace exerciseBox.Application.Services.Models
{
    public class SessionModel
    {
        public string SessionIdKey { get; set; }
        public string SessionId { get; set; }

        public static SessionModel DeserializeSessionModel(byte[] byteArray)
        {
            if (byteArray == null)
                return null;

            string jsonString = Encoding.UTF8.GetString(byteArray);
            SessionModel sessionModel = JsonSerializer.Deserialize<SessionModel>(jsonString);
            return sessionModel;
        }

        public static byte[] SerializeSessionModel(SessionModel sessionModel)
        {
            var jsonString = JsonSerializer.Serialize(sessionModel);
            return Encoding.UTF8.GetBytes(jsonString);
        }
    }
}