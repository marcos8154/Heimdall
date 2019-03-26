using System;
using System.Collections.Generic;
using System.Text;

namespace Heimdall.Domain.Exceptions
{
    public class ServiceException : Exception
    {
        public ServiceException(string message) : base(message)
        {
        }
    }
}
