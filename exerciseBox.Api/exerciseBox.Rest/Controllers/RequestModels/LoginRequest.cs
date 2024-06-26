namespace exerciseBox.Rest.Controllers.RequestModels
{
    /// <summary>
    /// Modell für die Anfrage zum Login.
    /// </summary>
    public class LoginRequest
    {
        /// <summary>
        /// Die E-Mail-Adresse des Benutzers.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Das Passwort des Benutzers.
        /// </summary>
        public string Password { get; set; }
    }
}
