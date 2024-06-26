namespace exerciseBox.Rest.Controllers.RequestModels
{
    /// <summary>
    /// Modell für eine Registrierungsanfrage.
    /// </summary>
    public class RegisterRequest
    {
        /// <summary>
        /// Die E-Mail-Adresse des Benutzers.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Der Nachname des Benutzers.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Der Vorname des Benutzers.
        /// </summary>
        public string Givenname { get; set; }

        /// <summary>
        /// Die ID der Schule, zu der der Benutzer gehört.
        /// </summary>
        public string SchoolId { get; set; }
    }
}
