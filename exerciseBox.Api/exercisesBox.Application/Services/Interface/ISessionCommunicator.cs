using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exerciseBox.Application.Services.Interface
{
    public interface ISessionCommunicator
    {
        string AddNewSessionId(string email);
        bool VerifySessionId(string sessionId); 

    }
}
