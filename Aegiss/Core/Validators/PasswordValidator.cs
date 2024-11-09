using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Aegiss.Core.Validators
{
    public static class PasswordValidator
    {
        public static bool Validate(string password)
        {
            if (password == null)
            {
                return false;
            }

            if (password.Length < 8)
            {
                return false;
            }

            if (!Regex.IsMatch(password, @"[A-Z]"))
            {
                return false;
            }
            
            if (!Regex.IsMatch(password, @"[a-z]"))
            {
                return false;
            }

            if (!Regex.IsMatch(password, @"[0-9]"))
            {
                return false;
            }

            if (!Regex.IsMatch(password, @"[!@#$%¨&*()_+\-=\[\]{};':""\\|,.<>\/?~ ]"))
            {
                return false;
            }

            return true;
        }
    }
}
