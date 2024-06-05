using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Domain.Entities;
using MediatR;

namespace exerciseBox.Application.UseCases.Teachers.Commands;

public class CreateTeacher : IRequest<TeacherDto>
{
    public TeacherDto Teacher { get; set; }
}
