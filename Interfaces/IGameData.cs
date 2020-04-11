namespace SpaceManager.Interfaces
{
    public interface IGameData
    {
        string SaveLocation { get; set; }
        void LoadData();
        void SaveData();
    }
}