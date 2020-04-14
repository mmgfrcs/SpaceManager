using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceManager.Interfaces
{
    public interface IComponent : ITick
    {
        bool IsActive { get; }
        string ComponentName { get; set; }
        string Category { get; }
        string Description { get; }
        double MaxDurability { get; }
        double CurrentDurability { get; set; }
        string GetFormattedString();
        string GetDetailString();
        void SetActive(bool active);
    }
}
