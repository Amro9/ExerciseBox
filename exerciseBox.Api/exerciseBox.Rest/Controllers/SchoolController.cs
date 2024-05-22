using exerciseBox.Application.UseCases.Schools.Commands;
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
    }
}
