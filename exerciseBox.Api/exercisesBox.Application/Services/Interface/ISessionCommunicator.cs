namespace exerciseBox.Application.Services.Interface
{
    /// <summary>
    /// Definiert Methoden zur Verwaltung von Sitzungs-IDs.
    /// </summary>
    public interface ISessionCommunicator
    {
        /// <summary>
        /// Fügt eine neue Sitzungs-ID hinzu.
        /// </summary>
        /// <returns>Die neu hinzugefügte Sitzungs-ID als Zeichenfolge.</returns>
        string AddNewSessionId();

        /// <summary>
        /// Überprüft die Gültigkeit einer Sitzungs-ID.
        /// </summary>
        /// <returns><c>true</c>, wenn die Sitzungs-ID gültig ist; andernfalls <c>false</c>.</returns>
        bool VerifySessionId();
    }
}
