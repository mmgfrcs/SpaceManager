using SpaceManager.Components;
using SpaceManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceManager
{
    [Serializable]
    struct GameDataStructure<T, U> where T : IPlayer where U : IStation
    {
        public T currentPlayer;
        public U currentStation;

        public GameDataStructure(T currentPlayer, U currentStation)
        {
            this.currentPlayer = currentPlayer;
            this.currentStation = currentStation;
        }
    }
}
