using System;
using SpaceManager.Engine;

namespace SpaceManager
{
    class Program
    {
        static void Main(string[] args)
        {
            GameEngine engine = new GameEngine();
            engine.Initialize();
            Console.WriteLine("Hello World!");
        }
    }
}
