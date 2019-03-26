using System;
using System.Collections.Generic;
using System.Text;

namespace Heimdall.Domain.Exceptions
{
    public class ConnectionFactoryException : Exception
    {
        public ConnectionFactoryException(string message) : base(message)
        {
        }
    }
}
