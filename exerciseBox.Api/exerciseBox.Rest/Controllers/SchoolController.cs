using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.UseCases.Schools.Commands;
using exerciseBox.Application.UseCases.Schools.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace exerciseBox.Rest.Controllers
{
    public class SchoolController : Controller
    {
        private readonly IMediator _mediator;

        public SchoolController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }

        public void AddSchool()
        {
            _mediator.Send(new CreateSchool
            {
            //    School = 
            });


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
        public async Task<SchoolDto> GetSchoolById(Guid id)
        {
            try
            {
                return await _mediator.Send(new GetSchoolById { Id = id });
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
