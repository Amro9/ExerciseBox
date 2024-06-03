using exerciseBox.Application.Abtraction.Models;
using MediatR;

namespace exerciseBox.Application.UseCases.Questions.Commands;

public class CreateQuestion : IRequest<QuestionDto>
{
    public QuestionDto Question { get; set; }
}
