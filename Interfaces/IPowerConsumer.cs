using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceManager.Interfaces
{
    interface IPowerConsumer
    {
        double CurrentPowerUsage { get; }
        double MinimumPowerUsage { get; }
        bool PartialFunctionAvailable { get; }

    }
}
