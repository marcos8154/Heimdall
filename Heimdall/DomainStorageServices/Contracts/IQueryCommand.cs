using System;
using System.Collections.Generic;
using System.Text;

namespace Heimdall.DomainStorageServices.Contracts
{
    internal interface IQueryCommand<T> where T: class
    {
        T Execute(StorageServiceBase storageService);
    }
}
