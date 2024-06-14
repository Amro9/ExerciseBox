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

namespace exerciseBox.Rest.Controllers
{
    public class SchoolController : BaseController
    {
        public SchoolController(IMediator mediator, ISessionCommunicator sessionCommunicator) : base(mediator, sessionCommunicator)
        {

        }



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
            [HttpGet("Types")]
            //public async Task<IActionResult> GetAllSchoolTypes(BaseRequest request)
            public async Task<IActionResult> GetAllSchoolTypes()
            {
                try
                {
                    //if (!_sessionCommunicator.VerifySessionId(new SessionModel { SessionIdKey = request.Id, SessionId = request.SessionId }))
                    //    return StatusCode(440, "Ihre Sitzung ist abgelaufen. Bitte melden sie sich erneut an.");

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
