using System.Collections.Generic;

namespace SpaceManager.Interfaces
{
    public interface IGameData
    {
        List<IMaterialData> MaterialDatabase { get; }
        string SaveLocation { get; set; }
        string MaterialFilesFolder { get; set; }
        void LoadData();
        void SaveData();
    }
}