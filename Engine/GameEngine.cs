using System;
using System.Collections.Generic;
using System.Threading;
using SpaceManager.Components;
using SpaceManager.Engine.Interfaces;
using SpaceManager.Interfaces;

namespace SpaceManager.Engine {
    public class GameEngine : IGameEngine, IInitializeRequired
    {
        //Game constants
        public const int TICK_TIME = 20;

        List<IGameState> gameStates = new List<IGameState>();
        IPlayer player;
        IStation station;
        Timer timer;

        double power = 0;

        public void Initialize() {
            Console.Clear();
            gameStates.Clear();

            player = new Player();
            player.Initialize("Player");

            station = new Station();
            station.AddComponent(new SolarPanel());
            station.AddComponent(new SolarPanel());

            for (int i = 0; i < station.GetComponentCount(); i++)
            {
                IComponent component = station.GetComponent(i);
                if (component is IInitializeRequired)
                    (component as IInitializeRequired).Initialize();
            }

            timer = new Timer(GameUpdate, null, TICK_TIME, TICK_TIME);
        }

        private void GameUpdate(object state)
        {
            station.Tick();
        }

        public void NextStep()
        {
            Console.Clear();
            for(int i = 0; i<station.GetComponentCount();i++)
            {
                IComponent component = station.GetComponent(i);
                if(component is IPowerGenerator)
                {
                    Console.WriteLine("{0}: +{1} W", component.ComponentName, (component as IPowerGenerator).CurrentPowerGeneration.ToString("n2"));
                    power += (component as IPowerGenerator).CurrentPowerGeneration * TICK_TIME / 1000;
                }
            }
            Console.WriteLine("Power: {0} Wh", power);
        }

        public void Print(string text)
        {
            Console.WriteLine(text);
        }

        public void Print(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public string RequestUserInput()
        {
            return Console.ReadLine();
        }

        
    }
}
