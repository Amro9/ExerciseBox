using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Services.Interface;
using exerciseBox.Application.Services.Models;
using exerciseBox.Application.UseCases.SchoolBranche.Queries;
using exerciseBox.Application.UseCases.SchoolLevels.Queries;
using exerciseBox.Application.UseCases.Schools.Commands;
using exerciseBox.Application.UseCases.Schools.Queries;
using exerciseBox.Application.UseCases.SchoolTypes.Queries;
using exerciseBox.Rest.Controllers.RequestModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace exerciseBox.Rest.Controllers
{
    /// <summary>
    /// Controller für Schuloperationen.
    /// </summary>
    public class SchoolController : BaseController
    {
        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="SchoolController"/> Klasse.
        /// </summary>
        /// <param name="mediator">Der MediatR-Mediator.</param>
        /// <param name="sessionCommunicator">Der Sitzungs-Kommunikator.</param>
        public SchoolController(IMediator mediator, ISessionCommunicator sessionCommunicator) : base(mediator, sessionCommunicator)
        {
        }

        /// <summary>
        /// Holt alle Schulen.
        /// </summary>
        /// <returns>Eine Liste von <see cref="SchoolDto"/> Objekten.</returns>
        [HttpGet("Schools")]
        public async Task<IEnumerable<SchoolDto>> GetAllSchools()
        {
            try
            {
                return await _mediator.Send(new GetAllSchools());
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Holt eine Schule anhand der ID.
        /// </summary>
        /// <param name="email">Die E-Mail der Schule.</param>
        /// <returns>Ein <see cref="SchoolDto"/> Objekt.</returns>
        [HttpGet("School/{id}")]
        public async Task<SchoolDto> GetSchoolById(string email)
        {
            try
            {
                return await _mediator.Send(new GetSchoolById { Email = email });
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Holt alle Schulzweige.
        /// </summary>
        /// <returns>Ein <see cref="IActionResult"/> mit der Liste von Schulzweigen.</returns>
        [HttpGet("branches")]
        public async Task<IActionResult> GetSchoolBranches()
        {
            try
            {
                var branches = await _mediator.Send(new GetAllSchoolBranches());
                return Ok(branches);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ein Fehler ist aufgetreten. Bitte versuchen Sie es später erneut.");
            }
        }

        /// <summary>
        /// Holt alle Schulstufen.
        /// </summary>
        /// <returns>Ein <see cref="IActionResult"/> mit der Liste von Schulstufen.</returns>
        [HttpGet("levels")]
        public async Task<IActionResult> GetSchoolLevels()
        {
            try
            {
                var levels = await _mediator.Send(new GetAllSchoolLevels());
                return Ok(levels);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ein Fehler ist aufgetreten. Bitte versuchen Sie es später erneut.");
            }
        }

        /// <summary>
        /// Holt alle Schultypen.
        /// </summary>
        /// <returns>Ein <see cref="IActionResult"/> mit der Liste von Schultypen.</returns>
        [HttpGet("Types")]
        public async Task<IActionResult> GetAllSchoolTypes()
        {
            try
            {
                var types = await _mediator.Send(new GetAllSchoolTypes());
                return Ok(types);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ein Fehler ist aufgetreten. Bitte versuchen Sie es später erneut.");
            }
        }
    }
}
