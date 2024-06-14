using System.Security.Cryptography;
using System.Text;

namespace exerciseBox.Application.Abtraction.Extensions
{
    /// <summary>
    /// Erweiterungsmethoden für das Hashen und Überprüfen von Passwörtern.
    /// </summary>
    public static class StringHashingExtension
    {
        /// <summary>
        /// Hasht das angegebene Passwort mit SHA-256.
        /// </summary>
        /// <param name="password">Das zu hashende Passwort.</param>
        /// <returns>Der gehashte Wert als Hexadezimalzeichenfolge.</returns>
        public static string HashPassword(this string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                string hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                return hash;
            }
        }

        /// <summary>
        /// Überprüft, ob das angegebene Passwort mit dem gegebenen Hash übereinstimmt.
        /// </summary>
        /// <param name="password">Das zu überprüfende Passwort.</param>
        /// <param name="hash">Der zu vergleichende Hash-Wert.</param>
        /// <returns>True, wenn das Passwort übereinstimmt; andernfalls false.</returns>
        public static bool VerifyPassword(this string password, string hash)
        {
            return password.HashPassword() == hash;
        }
    }
}
