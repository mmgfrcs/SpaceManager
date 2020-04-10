using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceManager.Engine.Interfaces
{
    public interface IGameStateData
    {
        string StateSaveLocation { get; set; }
        void SaveState();
        void LoadState();
    }
}
