using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceManager.Interfaces
{
    public interface ITick
    {
        bool TickEnabled { get; }
        void Tick();
    }
}
