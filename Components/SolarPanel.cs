using SpaceManager.Engine;
using SpaceManager.Interfaces;
using System;

namespace SpaceManager.Components
{
    [Serializable]
    class SolarPanel : IComponent, IPowerGenerator
    {
        public double CurrentPowerGeneration { get; private set; }
        public double MaximumPowerGeneration => 500;
        public double GenerationEfficiency => 1;
        public string ComponentName { get; set; } = "Solar Panel";
        public string Description => "Provides sunlight power";
        public double MaxDurability => 200;
        public double CurrentDurability { get; set; } = 200;
        public bool TickEnabled => CurrentDurability > 0;
        public string Category => "Solar Panels";

        public void Tick()
        {
            CurrentPowerGeneration = Math.Pow(Math.Abs(Math.Sin(Math.PI / 360 * GameEngine.RunningEngine.GameTime)), 2.5) * MaximumPowerGeneration;
        }
    }
}
