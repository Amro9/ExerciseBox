using MediatR;

namespace exerciseBox.Application.UseCases.SchoolLevels.Queries
{
    /// <summary>
    /// Query zur Abfrage der Schulstufen anhand der Lehrer-ID.
    /// </summary>
    public class GetSchoolLevelsByTeacherId : IRequest<IEnumerable<int>>
    {
        /// <summary>
        /// Die ID des Lehrers, für den die Schulstufen abgefragt werden sollen.
        /// </summary>
        public string TeacherId { get; set; }

        /// <summary>
        /// Konstruktor für die Initialisierung der Lehrer-ID.
        /// </summary>
        /// <param name="teacherId">Die ID des Lehrers.</param>
        public GetSchoolLevelsByTeacherId(string teacherId)
        {
            TeacherId = teacherId;
        }
    }
}
