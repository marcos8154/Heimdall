using Heimdall.Security.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heimdall.Security
{
    internal class DefaultEncryptor : IHeimdallCryptor
    {
        public string Decript(string text)
        {
            return "Default decryptor";
        }

        public string Encrypt(string text)
        {
            return "Default cryptor";
        }
    }
}
