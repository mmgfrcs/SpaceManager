using System;
using System.Collections.Generic;

using SpaceManager.Interfaces;
using SpaceManager.Components;

namespace SpaceManager
{
    public abstract class GameDataBase<T, U> : IGameData where T : IStation<U> where U : IPlayer
    {
        public T CurrentStation { get; set; }
        public string SaveLocation { get; set; } = "Data/GameData.json";

        public abstract void LoadData();

        public abstract void SaveData();
    }

}
