using System;
using System.Collections.Generic;
using System.Text;

namespace Heimdall.ConnectionFactory
{
    internal enum DatabaseType
    {
        PostgreSQL = 1,
        FirebirdSQL = 2,
        MySQL = 3,
        MSSQL = 4,
        JsonFileStorage = 5 
    }
}
