namespace exerciseBox.Rest.Controllers.RequestModels
{
    /// <summary>
    /// Modell für Anfragen, die nur eine E-Mail-Adresse enthalten.
    /// </summary>
    public class EmailRequest
    {
        /// <summary>
        /// Die E-Mail-Adresse.
        /// </summary>
        public string Email { get; set; }
    }
}
