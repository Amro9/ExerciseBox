using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.Teacher.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exerciseBox.Application.UseCases.Teacher.CommandHandlers
{
    /// <summary>
    /// Command-Handler zum Deaktivieren eines Lehrers.
    /// </summary>
    public class DeactivateTeacherHandler : IRequestHandler<DeactivateTeacher>
    {
        private readonly ITeacherRepository _teacherRepository;

        /// <summary>
        /// Konstruktor für den DeactivateTeacherHandler.
        /// </summary>
        /// <param name="teacherRepository"></param>
        public DeactivateTeacherHandler(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        /// <summary>
        /// Behandelt den Befehl zum Deaktivieren eines Lehrers.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task Handle(DeactivateTeacher request, CancellationToken cancellationToken)
        {
            await _teacherRepository.DeactivateTeacher(request.TeacherId);
        }
    }
}
