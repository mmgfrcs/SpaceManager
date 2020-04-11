using SpaceManager.Engine;
using System.Threading;

namespace SpaceManager
{
    class Program
    {
        static void Main(string[] args)
        {
            GameEngine engine = GameEngine.Initialize();
            while(true)
            {
                engine.NextStep();
                Thread.Sleep(500);
            }
        }
    }
}
