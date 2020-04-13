using SpaceManager.Components;
using SpaceManager.Interfaces;
using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using SpaceManager.Serialization;

namespace SpaceManager
{
    class GameData : GameDataBase<Station, Player>
    {
        
        public override void LoadData()
        {
            if(File.Exists(SaveLocation))
            {
                Station data = JsonConvert.DeserializeObject<Station>(File.ReadAllText(SaveLocation), new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.All,
                    SerializationBinder = new Whitelister()
                });
                CurrentStation = data;
                if (CurrentStation is IInitializeRequired) (CurrentStation as IInitializeRequired).Initialize();
            }
            else
            {
                CurrentStation = new Station();
                CurrentStation.Initialize();
                //SaveData();
            }
        }

        public override void SaveData()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(SaveLocation));
            File.WriteAllText(SaveLocation, JsonConvert.SerializeObject(CurrentStation, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All }));
        }
    }
}
