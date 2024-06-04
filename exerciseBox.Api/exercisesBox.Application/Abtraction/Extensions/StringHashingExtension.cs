using System.Security.Cryptography;
using System.Text;

namespace exerciseBox.Application.Abtraction.Extensions;

public static class StringHashingExtension
{
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

    public static bool VerifyPassword(this string password, string hash)
    {
        return password.HashPassword() == hash;    
    }
}
