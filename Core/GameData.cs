using SpaceManager.Components;
using SpaceManager.Interfaces;
using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace SpaceManager
{
    class GameData : GameDataBase<Player, Station>
    {
        
        public override void LoadData()
        {
            if(File.Exists(SaveLocation))
            {
                GameDataStructure<Player, Station> data =
                    JsonConvert.DeserializeObject<GameDataStructure<Player, Station>>(File.ReadAllText(SaveLocation));
                CurrentPlayer = data.currentPlayer;
                CurrentStation = data.currentStation;
                if (CurrentPlayer is IInitializeRequired) (CurrentPlayer as IInitializeRequired).Initialize();
                if (CurrentStation is IInitializeRequired) (CurrentStation as IInitializeRequired).Initialize();
            }
            else
            {
                CurrentPlayer = new Player();
                CurrentPlayer.Initialize("Player");
                CurrentStation = new Station();
                CurrentStation.Initialize();
                //SaveData();
            }
        }

        public override void SaveData()
        {
            GameDataStructure<Player, Station> data = new GameDataStructure<Player, Station>(CurrentPlayer, CurrentStation);
            File.WriteAllText(SaveLocation, JsonConvert.SerializeObject(data));
        }
    }
}
