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
    /// Command-Handler des Befehls zum aktivieren eines Lehrers.
    /// </summary>
    public class ActivateTeacherHandler : IRequestHandler<ActivateTeacher>
    {
        private readonly ITeacherRepository _teacherRepository;

        /// <summary>
        /// Konstruktor für den ActivateTeacherHandler.
        /// </summary>
        /// <param name="teacherRepository"></param>
        public ActivateTeacherHandler(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        /// <summary>
        /// Verarbeitet den Befehl zum aktivieren eines Lehrers.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task Handle(ActivateTeacher request, CancellationToken cancellationToken)
        {
            await _teacherRepository.ActivateTeacher(request.TeacherId);
        }
    }
}
