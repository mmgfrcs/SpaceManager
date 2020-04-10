using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceManager.Engine.Interfaces
{
    /// <summary>
    /// Provides general functionality of a game engine
    /// </summary>
    interface IGameEngine
    {
        /// <summary>
        /// Initializes the engine. Must be called before any other <see cref="IGameEngine"/> functions are called. Calling this after the first resets the game.
        /// </summary>
        void Initialize();
        string RequestUserInput();
        void NextStep();
        void Print(string text);
        void Print(string text, ConsoleColor color);
    }
}
