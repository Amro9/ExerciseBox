using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace exerciseBox.Rest.Controllers;

[ApiController]
[Produces("application/json")]
[Route("api/[controller]")]
[EnableCors("AllowAllOrigins")]
public abstract class BaseController : Controller
{
    protected readonly IMediator _mediator;
    public BaseController(IMediator mediator)
    {
        _mediator = mediator;
    }
}
