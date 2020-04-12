using SpaceManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceManager
{
    [Serializable]
    class Player : IPlayer, IPowerConsumer
    {
        public string PlayerName { get; private set; }
        public double CurrentPowerUsage => 10;
        public double MinimumPowerUsage => 0;
        public bool PartialFunctionAvailable => false;

        public void Initialize(string name)
        {
            PlayerName = name;
        }
    }
}
