using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace exerciseBox.Rest.Controllers
{
    /// <summary>
    /// Basisklasse für Controller mit gemeinsamen Konfigurationen und Diensten.
    /// </summary>
    [ApiController]
    [Produces("application/json", "application/pdf")]
    [Route("api/[controller]")]
    [EnableCors("AllowAllOrigins")]
    [Authorize]
    public abstract class BaseController : Controller
    {
        protected readonly IMediator _mediator;

        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="BaseController"/> Klasse.
        /// </summary>
        /// <param name="mediator">Der MediatR-Mediator für die Controlleraktionen.</param>
        public BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
