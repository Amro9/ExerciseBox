namespace exerciseBox.Rest.Controllers.RequestModels
{
    /// <summary>
    /// Modell für die Anfrage anhand einer Schul-ID und einer Sitzungs-ID.
    /// </summary>
    public class SchoolRequest
    {
        /// <summary>
        /// Die ID der Schule.
        /// </summary>
        public string SchoolId { get; set; }

        /// <summary>
        /// Die Sitzungs-ID.
        /// </summary>
        public string Seesionid { get; set; }
    }
}
