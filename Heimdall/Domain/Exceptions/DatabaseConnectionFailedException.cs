using Heimdall.Domain.Configurations;
using System;

namespace Heimdall.Domain.Exceptions
{
    public class DatabaseConnectionFailedException : Exception
    {
        public DatabaseConnectionFailedException(Exception inner)
            :base("", inner)
        {

        }
        
        private string GetDbVendor()
        {
            return HeimdallConfiguration.Instance.Database.GetDbVendor();
        }

        public override string Message
        {
            get
            {
                return $@"Failed to open a connection to the {GetDbVendor()} server. Perhaps the server is not accessible, or the data source configuration is missing.";
            }
        }
    }
}
