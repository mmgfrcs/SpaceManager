using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceManager.Interfaces
{
    public interface IMaterialStorage
    {
        List<IMaterial> MaterialStore { get; }
    }
}
