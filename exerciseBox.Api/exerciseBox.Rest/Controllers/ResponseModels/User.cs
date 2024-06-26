using exerciseBox.Application.Abtraction.Models;

namespace exerciseBox.Rest.Controllers.ResponseModels
{
    /// <summary>
    /// Repräsentiert einen Benutzer mit Email und Rolle.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Die E-Mail-Adresse des Benutzers.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Die Rolle des Benutzers.
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Implizite Konvertierung von <see cref="TeacherDto"/> zu <see cref="User"/>.
        /// </summary>
        /// <param name="v">Das <see cref="TeacherDto"/> Objekt, das konvertiert werden soll.</param>
        /// <returns>Ein <see cref="User"/> Objekt mit der E-Mail-Adresse aus dem <see cref="TeacherDto"/>.</returns>
        public static implicit operator User(TeacherDto v)
        {
            if (v == null)
            {
                return null;
            }

            return new User
            {
                Email = v.Email
            };
        }

        /// <summary>
        /// Implizite Konvertierung von <see cref="SchoolDto"/> zu <see cref="User"/>.
        /// </summary>
        /// <param name="v">Das <see cref="SchoolDto"/> Objekt, das konvertiert werden soll.</param>
        /// <returns>Ein <see cref="User"/> Objekt mit der E-Mail-Adresse aus dem <see cref="SchoolDto"/>.</returns>
        public static implicit operator User(SchoolDto v)
        {
            if (v == null)
            {
                return null;
            }

            return new User
            {
                Email = v.Email
            };
        }
    }
}
