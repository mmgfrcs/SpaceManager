﻿using SpaceManager.Engine;
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
        public bool IsActive { get; private set; } = true;

        public string GetFormattedString()
        {
            return string.Format("+{0:N2} W ({1:N2}%)", CurrentPowerGeneration, CurrentPowerGeneration / MaximumPowerGeneration * 100);
        }

        public void SetActive(bool active)
        {
            IsActive = active;
        }

        public void Tick()
        {
            CurrentPowerGeneration = Math.Pow(Math.Sin(Math.PI / 360 * GameEngine.RunningEngine.GameTime), 6) * MaximumPowerGeneration;
        }
    }
}
