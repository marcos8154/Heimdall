using System;
using System.Collections.Generic;
using System.Text;

namespace Heimdall.Security.Contracts
{
    public interface IHeimdallCryptor
    {
        string Encrypt(string text);

        string Decript(string text);
    }
}
