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

        GameDataBase<Station> gameData;
        Timer timer;

        private GameEngine() { }

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

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{gameData.CurrentStation.Player.PlayerName} - Healthy");
            Console.ResetColor();
            double hour = (GameTime % 360) / 360 * 24;
            TimeSpan gameTimeSpan = new TimeSpan(Convert.ToInt32(Math.Floor(GameTime / 360)) + 1, (int)Math.Floor(hour), (int)Math.Floor((hour - Math.Floor(hour)) * 60), 0);
            string clock = gameTimeSpan.ToString(@"\D%d\ hh\:mm");
            Console.SetCursorPosition(Console.WindowWidth - clock.Length, 0);
            Console.WriteLine(clock);
            Dictionary<string, StringBuilder> detailPrint = new Dictionary<string, StringBuilder>();

            for (int i = 0; i<gameData.CurrentStation.GetComponentCount(); i++)
            {
                IComponent component = gameData.CurrentStation.GetComponent(i);
                if (!detailPrint.ContainsKey(component.Category)) 
                    detailPrint.Add(component.Category, new StringBuilder(component.Category + ":\n"));
                
                detailPrint[component.Category].AppendLine($" - {component.ComponentName}: {component.GetFormattedString()}");
            }

            foreach(var print in detailPrint)
            {
                Console.WriteLine(print.Value.ToString());
            }

            Console.SetCursorPosition(0, Console.WindowHeight - 2);
            Console.WriteLine("[S]etup [A]ll");
            Console.Write(" > ");
        }
    }
}
