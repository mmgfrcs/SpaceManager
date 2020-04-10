using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceManager.Interfaces
{
    interface IPowerStorage
    {
        double CurrentCapacity { get; }
        double MaximumCapacity { get; }
        double StorageEfficiency { get; }
        double StorageDrain { get; }

    }
}
