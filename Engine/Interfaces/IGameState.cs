using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceManager.Engine.Interfaces
{
    public interface IGameState
    {
        int StateID { get; }
        void SetGameState(IGameStateData stateData);
        IGameStateData GetGameState();
    }
}
