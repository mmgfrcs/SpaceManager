using SpaceManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceManager
{
    class Player : IPlayer
    {
        public string PlayerName { get; private set; }

        public void Initialize(string name)
        {
            PlayerName = name;
        }
    }
}
