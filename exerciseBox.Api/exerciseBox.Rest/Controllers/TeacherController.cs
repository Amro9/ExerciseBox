using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.UseCases.Teacher.Queries;
using exerciseBox.Application.UseCases.Teachers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace exerciseBox.Rest.Controllers
{
    public class TeacherController : BaseController
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

        [HttpGet("Teachers/{Email}")]
        public async Task<TeacherDto> GetTeacherByEmail(string email)
        {
            return await _mediator.Send(new GetTeacherByEmail { Email = email });
        }
    }
}
