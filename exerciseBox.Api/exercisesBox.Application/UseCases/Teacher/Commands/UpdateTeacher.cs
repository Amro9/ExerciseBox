using exerciseBox.Application.Abtraction.Models;
using MediatR;

namespace exerciseBox.Application.UseCases.Teacher.Commands
{
    /// <summary>
    /// Befehl zum Aktualisieren eines Lehrers.
    /// </summary>
    public class UpdateTeacher : IRequest
    {
        public TeacherDto Teacher { get; set; } 
    }
}
