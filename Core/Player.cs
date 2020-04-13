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

        public void Initialize(string name)
        {
            PlayerName = name;
        }
    }
}
