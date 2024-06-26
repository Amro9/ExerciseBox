using MediatR;

namespace exerciseBox.Application.UseCases.SchoolLevels.Queries
{
    /// <summary>
    /// Query zur Abfrage aller Schulstufen.
    /// </summary>
    public class GetAllSchoolLevels : IRequest<IEnumerable<int>>
    {
        /// <summary>
        /// Konstruktor für die Initialisierung eines neuen Objekts der Klasse GetAllSchoolLevels.
        /// </summary>
        public GetAllSchoolLevels()
        {
            // Keine weiteren Parameter benötigt.
        }
    }
}
