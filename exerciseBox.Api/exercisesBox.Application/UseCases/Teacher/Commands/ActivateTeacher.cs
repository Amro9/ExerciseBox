using MediatR;

namespace exerciseBox.Application.UseCases.Teacher.Commands
{
    /// <summary>
    /// Befehl zum deaktivieren eines Lehrers.
    /// </summary>
    public class ActivateTeacher : IRequest
    {
        public string TeacherId { get; set; }
    }
}
