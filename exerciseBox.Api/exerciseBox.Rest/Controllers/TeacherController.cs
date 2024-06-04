using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.UseCases.Teacher.Queries;
using exerciseBox.Application.UseCases.Teachers.Queries;
using exerciseBox.Rest.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace exerciseBox.Rest.Controllers;

public class TeacherController : BaseController
{
    public TeacherController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet("All")]
    public async Task<IEnumerable<TeacherDto>> GetAllTeachers()
    {
        return await _mediator.Send(new GetAllTeachers());
    }

    [HttpPost("ByEmail")]
    public async Task<IActionResult> GetTeacherByEmail([FromBody] EmailRequest email)
    {
        try
        {
            var teacher = await _mediator.Send(new GetTeacherByEmail { Email = email.Email });
            return Ok(new { resultType = 0, value = teacher });
        }
        catch (Exception ex)
        {
            return BadRequest(new { resultType = 1, message = ex.Message });
        }
    }


}
