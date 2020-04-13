using System;
using System.Text;
using System.Collections.Generic;
using System.Threading;
using SpaceManager.Components;
using SpaceManager.Interfaces;

namespace SpaceManager.Engine {

    public enum GameOptions
    {
        Home, Overview, Exit
    }

    public class GameEngine
    {
        //Game constants
        public const int TICK_TIME = 20;
        public static GameEngine RunningEngine;
        
        public double GameTime { get; private set; } = 90;

        GameDataBase<Station, Player> gameData;
        Timer timer;
        GameOptions options = GameOptions.Home;

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

        public bool NextStep()
        {
            Console.Clear();

            double hungerAmt = gameData.CurrentStation.Player.Hunger;
            double healthAmt = gameData.CurrentStation.Player.Health;
            string hunger = hungerAmt < 10 ? "Starving" : hungerAmt < 30 ? "Extremely Hungry" : hungerAmt < 50 ? "Very Hungry" : hungerAmt < 80 ? "Hungry" : "Full";
            string health = healthAmt < 20 ? "Critical" : healthAmt < 40 ? "Very Sick" : healthAmt < 75 ? "Sick" : "Healthy";
            ConsoleColor hungerColor = hungerAmt < 30 ? ConsoleColor.Red : hungerAmt < 80 ? ConsoleColor.Yellow : ConsoleColor.Green; 
            ConsoleColor healthColor = healthAmt < 20 ? ConsoleColor.Red : healthAmt < 75 ? ConsoleColor.Yellow : ConsoleColor.Green;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{gameData.CurrentStation.Player.PlayerName} - ");
            Console.ForegroundColor = hungerColor;
            Console.Write($"{hunger}, ");
            Console.ForegroundColor = healthColor;
            Console.WriteLine(health);
            Console.ResetColor();
            double hour = (GameTime % 360) / 360 * 24;
            TimeSpan gameTimeSpan = new TimeSpan(Convert.ToInt32(Math.Floor(GameTime / 360)) + 1, (int)Math.Floor(hour), (int)Math.Floor((hour - Math.Floor(hour)) * 60), 0);
            string clock = gameTimeSpan.ToString(@"\D%d\ hh\:mm");
            Console.SetCursorPosition(Console.WindowWidth - clock.Length, 0);
            Console.WriteLine(clock);
            
            if (options == GameOptions.Exit)
                return false;
            else if (options == GameOptions.Overview)
            {
                Dictionary<string, StringBuilder> detailPrint = new Dictionary<string, StringBuilder>();

                for (int i = 0; i < gameData.CurrentStation.GetComponentCount(); i++)
                {
                    IComponent component = gameData.CurrentStation.GetComponent(i);
                    if (!detailPrint.ContainsKey(component.Category))
                        detailPrint.Add(component.Category, new StringBuilder(component.Category + ":\n"));

                    detailPrint[component.Category].AppendLine($" - {component.ComponentName}: {component.GetFormattedString()}");
                }

                foreach (var print in detailPrint)
                {
                    Console.WriteLine(print.Value.ToString());
                }
            }
            else if (options == GameOptions.Home)
            {
                double powerGen = 0, powerUse = 0, powerStore = 0;
                for (int i = 0; i < gameData.CurrentStation.GetComponentCount(); i++)
                {
                    IComponent component = gameData.CurrentStation.GetComponent(i);
                    if (component is IPowerGenerator gen)
                        powerGen += gen.CurrentPowerGeneration;
                    else if (component is IPowerConsumer con)
                        powerUse += con.CurrentPowerUsage;
                    else if (component is IPowerStorage sto)
                        powerStore += sto.CurrentCapacity;
                                        
                }

                Console.WriteLine($"Power Generation : {powerGen.ToString("n1")} W");
                Console.WriteLine($"Power Consumption: {powerUse.ToString("n1")} W");
                Console.WriteLine($"Power Storage    : {(powerStore / 3600).ToString("n1")} Wh");
            }

            return true;

        }

        public void RequestInput()
        {
            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            if(options == GameOptions.Home)
            {
                Console.Write("[O]verview [E]xit");
                ConsoleKeyInfo info = Console.ReadKey(true);

                if (info.Key == ConsoleKey.E)
                    options = GameOptions.Exit;
                else if (info.Key == ConsoleKey.O)
                    options = GameOptions.Overview;
            }
            else if (options == GameOptions.Overview)
            {
                Console.Write("[B]ack [E]xit");
                ConsoleKeyInfo info = Console.ReadKey(true);

                if (info.Key == ConsoleKey.E)
                    options = GameOptions.Exit;
                else if (info.Key == ConsoleKey.B)
                    options = GameOptions.Home;
            }
        }
    }
}
