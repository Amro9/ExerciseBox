using MediatR;

namespace exerciseBox.Application.UseCases.Teacher.Commands
{
    public class UpdatePassword : IRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
