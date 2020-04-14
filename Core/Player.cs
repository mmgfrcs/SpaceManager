using SpaceManager.Engine;
using SpaceManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceManager
{
    [Serializable]
    class Player : IPlayer
    {
        public string PlayerName { get; private set; }
        public double Health { get; set; } = 100;
        public double Hunger { get; set; } = 100;
        public List<IMaterial> RequiredMaterials { get; private set; }
        public bool TickEnabled => true;

        public void Initialize(string name)
        {
            PlayerName = name;
            RequiredMaterials = new List<IMaterial>()
            {
                new Material(GameEngine.RunningEngine.GetMaterialData("food"), (GameEngine.TICK_TIME/1000D)/360),
                new Material(GameEngine.RunningEngine.GetMaterialData("water"), (2 * GameEngine.TICK_TIME/1000D)/360)
            };
        }

    }
}
