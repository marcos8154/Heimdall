using Heimdall.Domain.Contracts;
using Heimdall.Domain.Exceptions;

namespace Heimdall.Security
{
    internal class HightLevelPasswordSecurityValidator : IUserPasswordSecurityValidator
    {
        public void ValidPasswordSecurity(string password)
        {
            string msg = "Weak password. The password must contain at least 15 characters, being at least 7 letters, 5 numbers and 3 special character";
            if (string.IsNullOrEmpty(password) ||
                string.IsNullOrWhiteSpace(password))
                throw new WeakPasswordException(msg,
                    8, 100, 7, 4, 3);
            if (password.Length < 15)
                throw new WeakPasswordException(msg,
                      8, 100, 7, 4, 3);

            int chars = 0;
            int numbers = 0;
            int specialChars = 0;

            foreach (char ch in password)
            {
                if (char.IsLetter(ch))
                    chars += 1;
                else if (char.IsNumber(ch))
                    numbers += 1;
                else specialChars += 1;
            }

            if (chars < 7)
                throw new WeakPasswordException(msg,
                     8, 100, 5, 2, 1);
            if (numbers < 4)
                throw new WeakPasswordException(msg,
                 8, 100, 5, 2, 1);
            if (specialChars < 3)
                throw new WeakPasswordException(msg,
                 8, 100, 5, 2, 1);
        }
    }
}
