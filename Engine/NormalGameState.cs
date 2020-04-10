using SpaceManager.Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceManager.Engine
{
    class NormalGameState : IGameState
    {
        public int StateID { get; internal set; }

        public IGameStateData GetGameState()
        {
            throw new NotImplementedException();
        }

        public void SetGameState(IGameStateData stateData)
        {
            throw new NotImplementedException();
        }
    }

    struct GameData : IGameStateData
    {
        public string StateSaveLocation { get; set; }

        public void LoadState()
        {
            throw new NotImplementedException();
        }

        public void SaveState()
        {
            throw new NotImplementedException();
        }
    }
}
