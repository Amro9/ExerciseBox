using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.UseCases.Teachers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace exerciseBox.Rest.Controllers
{
    public class TeacherController : Controller
    {
        private readonly IMediator _mediator;
        public TeacherController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Teachers")]
        public async Task<IEnumerable<TeacherDto>> GetAllTeachers()
        {
            return await _mediator.Send(new GetAllTeachers());
        }
    }
}
