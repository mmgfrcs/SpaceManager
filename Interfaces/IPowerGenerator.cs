using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceManager.Interfaces
{
    interface IPowerGenerator
    {
        double CurrentPowerGeneration { get; }
        double MaximumPowerGeneration { get; }
        double GenerationEfficiency { get; }
    }
}
