using Konscious.Security.Cryptography;
using System.Security.Cryptography;
using System.Text;

namespace Aegiss.Core.Services
{
    public class HashService
    {
        public static bool VerifyPassword(string password, string hashPassword)
        {
            var computedHash = HashPassword(password);
            return computedHash == hashPassword;
        }

        public static string HashPassword(string password)
        {
            using (var hasher = new Argon2i(Encoding.UTF8.GetBytes(password)))
            {
                hasher.DegreeOfParallelism = 8;
                hasher.Iterations = 4;
                hasher.MemorySize = 65536;
                hasher.Salt = new byte[16];

                return Convert.ToBase64String(hasher.GetBytes(32));
            }
        }
    }
}
