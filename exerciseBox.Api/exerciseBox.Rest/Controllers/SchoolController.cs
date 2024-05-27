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

        public SchoolController(IMediator mediator  )
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
            return await _mediator.Send(new GetAllSchools());
        }
    }
}
