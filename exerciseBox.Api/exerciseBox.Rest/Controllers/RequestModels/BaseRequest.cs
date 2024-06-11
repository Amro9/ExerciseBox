using Microsoft.Identity.Client;

namespace exerciseBox.Rest.Controllers.RequestModels;

public class BaseRequest
{
    public string Id { get; set; }
    public string SessionId { get; set; }
}
