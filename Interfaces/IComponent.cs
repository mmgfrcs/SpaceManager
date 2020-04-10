using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceManager.Interfaces
{
    public interface IComponent : ITick
    {
        string ComponentName { get; set; }
        string Description { get; }
        double MaxDurability { get; }
        double CurrentDurability { get; }
    }
}
