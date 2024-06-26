using MediatR;

namespace exerciseBox.Application.UseCases.SchoolLevels.Queries
{
    /// <summary>
    /// Query zur Abfrage der Schulstufen anhand der Schultyp-ID.
    /// </summary>
    public class GetSchoolLevelsBySchoolTypeId : IRequest<IEnumerable<int>>
    {
        /// <summary>
        /// Die ID des Schultyps, für den die Schulstufen abgefragt werden sollen.
        /// </summary>
        public int SchoolTypeId { get; set; }

        /// <summary>
        /// Konstruktor für die Initialisierung der Schultyp-ID.
        /// </summary>
        /// <param name="schoolTypeId">Die ID des Schultyps.</param>
        public GetSchoolLevelsBySchoolTypeId(int schoolTypeId)
        {
            SchoolTypeId = schoolTypeId;
        }
    }
}
