using System;
using System.Collections.Generic;
using System.Text;

namespace Heimdall.Security.Contracts
{
    public interface IHeimdallCryptor
    {
        void SetPassword(string encryptionPassword);

        string Encrypt(string text);

        string Decrypt(string text);
    }
}
