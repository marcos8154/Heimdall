using Heimdall.Domain.Contracts;
using Heimdall.Domain.Exceptions;

namespace Heimdall.Security
{
    internal class MediumLevelPasswordSecurityValidator : IUserPasswordSecurityValidator
    {
        public void ValidPasswordSecurity(string password)
        {
            string msg = "Weak password. The password must contain at least 8 characters, being at least 5 letters, 2 numbers and 1 special character";
            if (string.IsNullOrEmpty(password) ||
                       string.IsNullOrWhiteSpace(password))
                throw new WeakPasswordException(msg,
                    8, 100, 5, 2, 1);
            if (password.Length < 8)
                throw new WeakPasswordException(msg,
                      8, 100, 5, 2, 1);

            int chars = 0;
            int numbers = 0;
            int specialChars = 0;

            foreach(char ch in password)
            {
                if (char.IsLetter(ch))
                    chars += 1;
                else if (char.IsNumber(ch))
                    numbers += 1;
                else specialChars += 1;
            }

            if(chars < 5)
                throw new WeakPasswordException(msg,
                     8, 100, 5, 2, 1);
            if(numbers < 2)
                throw new WeakPasswordException(msg,
                 8, 100, 5, 2, 1);
            if(specialChars < 1)
                throw new WeakPasswordException(msg,
                 8, 100, 5, 2, 1);
        }
    }
}
