using System;
using System.Collections.Generic;
using System.Text;

namespace Heimdall.DomainStorageServices.Contracts
{
    internal interface IStorageCommand
    {
        void Execute(StorageServiceBase storageService);
    }
}
