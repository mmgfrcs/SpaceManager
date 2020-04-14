using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceManager.Interfaces
{
    public interface IMaterialConsumer
    {
        List<IMaterial> RequiredMaterials { get; }
    }
}
