using Asp.Versioning;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace exerciseBox.Rest.Controllers;

[ApiController]
[Produces("application/json")]
[Route("api/[controller]")]
[EnableCors("AllowAllOrigins")]
public abstract class BaseController
{

}
