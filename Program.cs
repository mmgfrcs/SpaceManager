using SpaceManager.Engine;
using System.Threading;

namespace SpaceManager
{
    class Program
    {
        static void Main(string[] args)
        {
            GameEngine engine = new GameEngine();
            engine.Initialize();
            while(true)
            {
                engine.NextStep();
                Thread.Sleep(500);
            }
        }
    }
}
