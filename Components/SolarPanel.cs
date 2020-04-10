using SpaceManager.Engine;
using SpaceManager.Interfaces;
using System;

namespace SpaceManager.Components
{
    class SolarPanel : IComponent, IPowerGenerator
    {
        public double CurrentPowerGeneration { get; private set; }
        public double MaximumPowerGeneration => 500;
        public double GenerationEfficiency => 1;
        public string ComponentName { get; set; } = "Solar Panel";
        public string Description => "Provides sunlight power";
        public double MaxDurability => 200;
        public double CurrentDurability { get; private set; } = 200;
        public bool TickEnabled => CurrentDurability > 0;
        double time = 90;

        public void Tick()
        {
            time += GameEngine.TICK_TIME / 1000D;
            CurrentPowerGeneration = Math.Pow(Math.Abs(Math.Sin(Math.PI / 360 * time)), 2.5) * MaximumPowerGeneration;
        }
    }
}
