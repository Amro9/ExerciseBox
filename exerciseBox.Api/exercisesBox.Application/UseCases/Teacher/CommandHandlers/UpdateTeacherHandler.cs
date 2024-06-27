using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.Teacher.Commands;
using MediatR;

namespace exerciseBox.Application.UseCases.Teacher.CommandHandlers
{
    /// <summary>
    /// Befehlsbehandlung zum Aktualisieren eines Lehrers.
    /// </summary>
    public class UpdateTeacherHandler : IRequestHandler<UpdateTeacher>
    {
        private readonly ITeacherRepository _teacherRepository;

        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="UpdateTeacherHandler"/> Klasse.
        /// </summary>
        /// <param name="teacherRepository"></param>
        public UpdateTeacherHandler(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        /// <summary>
        /// Behandelt den Befehl zum Aktualisieren eines Lehrers.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task Handle(UpdateTeacher request, CancellationToken cancellationToken)
        {
            var oldTeacher = await _teacherRepository.ReadByEmailAsync(request.Teacher.Email);

            if (oldTeacher == null)
            {
                throw new Exception("Teacher not found");
            }

            oldTeacher.Surname = request.Teacher.Surname;
            oldTeacher.FamilyName = request.Teacher.Givenname;
            oldTeacher.Email = request.Teacher.Email;
            oldTeacher.IsActive = request.Teacher.IsActive;

            var teacher = await _teacherRepository.UpdateAsync(oldTeacher);
            if(teacher == null)
            {
                throw new Exception("Teacher not updated");
            }
        }
    }
}
