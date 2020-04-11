using System;
using System.Text;
using System.Collections.Generic;
using System.Threading;
using SpaceManager.Components;
using SpaceManager.Interfaces;

namespace SpaceManager.Engine {
    public class GameEngine
    {
        //Game constants
        public const int TICK_TIME = 20;
        public static GameEngine RunningEngine;

        public double GameTime { get; private set; } = 90;

        GameDataBase<Player, Station> gameData;
        Timer timer;

        private GameEngine()
        {

        }

        public static GameEngine Initialize() {
            RunningEngine = new GameEngine();
            Console.Clear();
            RunningEngine.gameData = new GameData();

            RunningEngine.gameData.LoadData();

            RunningEngine.timer = new Timer(RunningEngine.GameUpdate, null, TICK_TIME, TICK_TIME);
            return RunningEngine;
        }

        private void GameUpdate(object state)
        {
            GameTime += TICK_TIME / 1000D;
            gameData.CurrentStation.Tick();
        }

        public void NextStep()
        {
            Console.Clear();

            Dictionary<string, StringBuilder> detailPrint = new Dictionary<string, StringBuilder>();

            for (int i = 0; i<gameData.CurrentStation.GetComponentCount(); i++)
            {
                IComponent component = gameData.CurrentStation.GetComponent(i);
                if (!detailPrint.ContainsKey(component.Category))
                    detailPrint.Add(component.Category, new StringBuilder(component.Category + ":\n"));

                string appendString = "";
                if (component is IPowerGenerator)
                {
                    IPowerGenerator generator = component as IPowerGenerator;
                    appendString = $" - {component.ComponentName}: +{generator.CurrentPowerGeneration.ToString("n2")} W ({(generator.CurrentPowerGeneration / generator.MaximumPowerGeneration * 100).ToString("n2")}%)";
                }
                if (component is IPowerStorage)
                {
                    IPowerStorage storage = component as IPowerStorage;
                    appendString = $" - {component.ComponentName}: {(storage.CurrentCapacity/3600).ToString("n2")} Wh ({(storage.CurrentCapacity / storage.MaximumCapacity * 100).ToString("n2")}%)";
                }
                detailPrint[component.Category].AppendLine(appendString);
                
            }

            foreach(var print in detailPrint)
            {
                Console.WriteLine(print.Value.ToString());
            }
        }
    }
}
