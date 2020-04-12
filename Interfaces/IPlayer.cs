using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceManager.Interfaces
{
    public interface IPlayer
    {
        string PlayerName { get; }
        void Initialize(string name);
    }
}
