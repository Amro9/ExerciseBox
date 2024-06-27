using MediatR;

namespace exerciseBox.Application.UseCases.Teacher.Commands
{
    public class ResetPassword : IRequest
    { 
        public string Email { get; set; }
    }
}
