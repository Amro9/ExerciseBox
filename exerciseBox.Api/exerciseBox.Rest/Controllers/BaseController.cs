using exerciseBox.Application.Services.Interface;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace exerciseBox.Rest.Controllers;

[ApiController]
[Produces("application/json", "application/pdf")]
[Route("api/[controller]")]
[EnableCors("AllowAllOrigins")]
[Authorize]
public abstract class BaseController : Controller
{
    protected readonly IMediator _mediator;
    protected readonly ISessionCommunicator _sessionCommunicator;
    public BaseController(IMediator mediator, ISessionCommunicator sessionCommunicator)
    {
        _mediator = mediator;
        _sessionCommunicator = sessionCommunicator;
    }
}
